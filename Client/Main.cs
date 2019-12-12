using ChatApp.Library;
using Client.Properties;
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
            client.OnConnectedToServer += OnConnectedToServer;
            client.UpdateMessages += UpdateMessages;
            client.OnDisconnectedFromServer += OnDisconnectedFromServer;
            client.PopulateOnlineUsers += PopulateOnlineUsers;
        }

        private void PopulateOnlineUsers(List<User> users)
        {
            onlineUsers.Items.Clear();
            foreach (var user in users)
            {
                ListViewItem lvi = new ListViewItem(user.Username);
                onlineUsers.Items.Add(lvi);
            }
        }

        private void OnDisconnectedFromServer()
        {
            Invoke(new Action(() => { connectButton.Enabled = true; }));
            Invoke(new Action(() => { pictureBox1.Image = Resources.DisconIco; }));
            Invoke(new Action(() => { disconnectButton.Enabled = false; }));
            Invoke(new Action(() => { messageButton.Enabled = false; }));

        }

        private void UpdateMessages(Message msg)
        {
            var lvi = new ListViewItem(new string[] { msg.User.Username, msg.Content });
            Invoke(new Action(() => { listView1.Items.Add(lvi); }));
        }

        private void OnConnectedToServer(bool obj)
        {
            if (!obj)
            {
                MessageBox.Show("Failed to connect to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Invoke(new Action(() => { connectButton.Enabled = false;
                    pictureBox1.Image = Resources.ConIco;
                    this.ActiveControl = messageBox;
                    this.AcceptButton = messageButton;
                    disconnectButton.Enabled = true;
                    messageButton.Enabled = true;
                }));
            }
        }


        

        private void connectButton_Click(object sender, EventArgs e)
        {
            client.Start();
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            client.messageQueue.Add(new Message("discon", 0, 0, "", client.currentUser, null));
        }

        private void MessageButton_Click(object sender, EventArgs e)
        {
            if (client.server.Connected)
            {
                client.messageQueue.Add(new Message("msg", 0, 0, messageBox.Text, client.currentUser, null));
                messageBox.Text = "";
            }
            else
            {
                MessageBox.Show("Not connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            client.username = textBox1.Text;
        }
    }
}
