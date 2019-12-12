using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ChatApp.Library
{
    public class Client
    {
        public Client(TcpClient client, NetworkStream stream, User user, Timer timer, List<Message> messageQueue)
        {
            this.client = client;
            this.stream = stream;
            this.user = user;
            this.timer = timer;
            this.messageQueue = messageQueue;
        }

        public TcpClient client { get; set; }
        public NetworkStream stream { get; set; }
        public User user { get; set; }
        public System.Timers.Timer timer { get; set; }
        public List<Message> messageQueue { get; set; }
    }
}
