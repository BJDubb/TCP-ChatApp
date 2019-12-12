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
        public event Action<bool> OnConnectedToServer;
        public event Action<List<Message>> UpdateMessages;
        public List<Message> messageQueue = new List<Message>();
        public List<Message> recievedMessages = new List<Message>();
        public TcpClient server = null;
        System.Timers.Timer timer = new System.Timers.Timer(5000);

        public void Start()
        {
            Thread clientThread = new Thread(new ThreadStart(Connect));
            clientThread.Start();
        }

        public void Connect()
        {
            server = new TcpClient();
            try { server.Connect("bjdubb.com", 5050); }
            catch (Exception e) { OnConnectedToServer(false); return; }

            OnConnectedToServer(true);

            HandleServer();
        }

        private void HandleServer()
        {
            NetworkStream stream = server.GetStream();
            Message message = new Message("con", 0, 0, "", new User(0, "BJDubb")); // Needs to be changed for users
            byte[] data = Convert.ToByteArray(message);
            stream.Write(data, 0, data.Length);
            stream.Flush();

            timer.Elapsed += (s, e) => HeartbeatExpire();
            timer.Start();

            while (server.Connected)
            {
                RecieveMessage(stream);
                SendMessage(stream);
                UpdateMessages(recievedMessages);
                recievedMessages = new List<Message>();
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
                                timer.Interval = 5000;
                                Console.WriteLine("Heartbeat");
                                break;
                            case "msg":
                                recievedMessages.Add(message);
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

        private void HeartbeatExpire()
        {
            server.Close();
            Console.WriteLine("Termnate");
        }


    }
}
