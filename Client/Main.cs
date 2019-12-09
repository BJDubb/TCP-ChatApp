using ChatApp.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = ChatApp.Library.Message;

namespace ChatApp.Client
{
    public partial class Main : Form
    {
        Client client = new Client();
        public Main()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            client.Start();
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            client.messageQueue.Add(new Message("discon", 0, 0, "", new User(0, "BJDubb")));
        }

        private void MessageButton_Click(object sender, EventArgs e)
        {
            if (client.server.Connected)
            {
                client.messageQueue.Add(new Message("msg", 0, 0, messageBox.Text, new User(0, "BJDubb")));
            }
            else
            {
                Console.WriteLine("Not connected");
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

            Environment.Exit(0);
        }
    }
}
