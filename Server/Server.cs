using ChatApp.Library;
using System;
using System.Collections.Generic;
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
        public Dictionary<TcpClient, User> clients = new Dictionary<TcpClient, User>();
        System.Timers.Timer timer = null;

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
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            timer = new System.Timers.Timer(2000);
            timer.Start();
            timer.Elapsed += (sender, e) => Heartbeat(client);

            while (true)
            {
                if (stream.CanRead)
                {
                    if (stream.DataAvailable)
                    {
                        Message message = Convert.ConvertMessage(stream);
                        if (message.Type != null)
                        {
                            switch (message.Type)
                            {
                                case "con":
                                    Log(message.User.Username + " has Connected.", User.Server);
                                    clients.Add(client, message.User);
                                    BeginHeartbeat(stream);
                                    break;
                                case "discon":
                                    Log(message.User.Username + " has Disconnected.", User.Server);
                                    clients.Remove(client);
                                    stream.Close();
                                    client.Close();
                                    break;
                                case "hrt":
                                    Log("heartbeat.", message.User);
                                    break;
                                case "msg":
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
        }


        private void Heartbeat(TcpClient client)
        {
            if (client.Connected)
            {
                NetworkStream stream = client.GetStream();
                if (stream.CanWrite)
                {
                    try
                    {
                        Message message = new Message("hrt", 0, 0, "", User.Server);
                        byte[] data = Convert.ToByteArray(message);
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                        timer.Interval = 2000;
                    }
                    catch
                    {
                        var pair = clients.First(x => x.Key == client);
                        clients.Remove(pair.Key);
                        client.Close();
                        Log(pair.Value.Username + " timed out", User.Server);
                    }
                }
            }
        }

        private void BeginHeartbeat(NetworkStream stream)
        {
            Message message = new Message("hrt", 0, 0, "", User.Server);
            byte[] data = Convert.ToByteArray(message);
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }

        private void Log(string message, User user = null)
        {
            user = user ?? new User(0, "Default");
            Console.WriteLine($"[{DateTime.Now}] [{user.Username}] : {message}");
        }

        

    }

}
