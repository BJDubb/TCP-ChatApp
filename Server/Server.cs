using ChatApp.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Convert = ChatApp.Library.Convert;

namespace ChatApp.Server
{
    public class Server
    {
        public bool running = false;
        public TcpListener listener;
        public List<Client> clients = new List<Client>();

        public Server()
        {
            Thread serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Name = "ServerThread";
            serverThread.Start();
        }

        private void StartServer()
        {
            listener = new TcpListener(IPAddress.Any, 5050);
            listener.Start();
            Console.WriteLine("Server Start");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThread.Name = "ClientThread";
                Console.WriteLine("New Client");
                clientThread.Start(client);
                Thread.Sleep(10);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient TcpClient = (TcpClient)obj;

            Client client = new Client(TcpClient, TcpClient.GetStream(), new User(-1, null), new System.Timers.Timer(2000), new List<Message>());
            clients.Add(client);

            client.timer.Start();
            client.timer.Elapsed += (sender, e) => Heartbeat(client);


            while (true)
            {
                Recieve(client);
                Send(client);
                Thread.Sleep(10);
            }
        }

        private void Send(Client client)
        {
            if (client.stream.CanWrite)
            {
                if (client.messageQueue.Count > 0)
                {
                    Debug.WriteLine(client.messageQueue.Count);

                    
                    byte[] data = Convert.ToByteArray(client.messageQueue[0]);
                    client.stream.Write(data, 0, data.Length);
                    client.stream.Flush();
                   
                    if (client.messageQueue[0].Type == "discon") DisconnectClient(client);
                    client.messageQueue.RemoveAt(0);
                }
            }
        }

        private void Recieve(Client client)
        {
            if (client.stream.CanRead)
            {
                if (client.stream.DataAvailable)
                {
                    Message message = Convert.ConvertMessage(client.stream);
                    if (message.Type != null)
                    {
                        switch (message.Type)
                        {
                            case "con":
                                Log(message.User.Username + " has Connected.", User.Server);
                                client.user = message.User;
                                BeginHeartbeat(client);
                                break;
                            case "discon":
                                Log(message.User.Username + " has Disconnected.", User.Server);
                                DisconnectClient(client);
                                break;
                            case "hrt":
                                Log("heartbeat.", message.User);
                                break;
                            case "msg":
                                foreach (var c in clients)
                                {
                                    c.messageQueue.Add(message);
                                }
                                Log(message.Content, message.User);
                                break;
                            default:
                                Log("Error", message.User);
                                break;
                        }
                    }
                }
            }
        }

        private void DisconnectClient(Client client)
        {
            clients.Remove(client);
            client.client.Close();
        }

        private void Heartbeat(Client client)
        {
            if (client.client.Connected)
            {
                if (client.stream.CanWrite)
                {
                    try
                    {
                        List<User> users = new List<User>();
                        for (int i = 0; i < clients.Count; i++)
                        {
                            users.Add(clients[i].user);
                        }
                        Message message = new Message("hrt", 0, 0, "", User.Server, users);
                        byte[] data = Convert.ToByteArray(message);
                        client.stream.Write(data, 0, data.Length);
                        client.stream.Flush();
                        client.timer.Interval = 2000;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        clients.Remove(client);
                        client.client.Close();
                        Log(client.user.Username + " timed out", User.Server);
                    }
                }
            }
        }

        private void BeginHeartbeat(Client client)
        {
            List<User> users = new List<User>();
            for (int i = 0; i < clients.Count; i++)
            {
                users.Add(clients[i].user);
            }
            Message message = new Message("hrt", 0, 0, "", User.Server, users);
            byte[] data = Convert.ToByteArray(message);
            client.stream.Write(data, 0, data.Length);
            client.stream.Flush();
        }

        private void Log(string message, User user = null)
        {
            user = user ?? new User(0, "Default");
            Console.WriteLine($"[{DateTime.Now}] [{user.Username}] : {message}");
        }

        

    }

}
