using System;
using ChatApp.Library;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Convert = ChatApp.Library.Convert;

namespace ChatApp.Client
{
    public class Client
    {
        public List<Message> messageQueue = new List<Message>();
        public List<Message> recievedMessages = new List<Message>();
        public TcpClient server = null;

        public void Start()
        {
            Thread clientThread = new Thread(new ThreadStart(Connect));
            clientThread.Start();
        }

        public void Connect()
        {
            server = new TcpClient();
            try { server.Connect("127.0.0.1", 5050); }
            catch (Exception e) { Console.WriteLine("Could not connect to server."); return; }
            
            HandleServer();
        }

        private void HandleServer()
        {
            NetworkStream stream = server.GetStream();
            Message message = new Message("con", 0, 0, "", new User(0, "BJDubb")); // Needs to be changed for users
            byte[] data = Convert.ToByteArray(message);
            stream.Write(data, 0, data.Length);
            stream.Flush();

            while (server.Connected)
            {
                RecieveMessage(stream);
                SendMessage(stream);
            }
        }

        private void RecieveMessage(NetworkStream stream)
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
                            case "discon":
                                Console.WriteLine("Server Disconnected");
                                server.Close();
                                break;
                            case "hrt":
                                Console.WriteLine("Heartbeat");
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                    }
                }
            }
        }

        private void SendMessage(NetworkStream stream)
        {
            if (stream.CanWrite)
            {
                if (messageQueue.Count > 0)
                {
                    byte[] data = Convert.ToByteArray(messageQueue[0]);
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                    if (messageQueue[0].Type == "discon") server.Close();
                    messageQueue.RemoveAt(0);
                }
            }
        }
    }
}
