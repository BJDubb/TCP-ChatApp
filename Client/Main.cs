using ChatApp.Library;
using Client.Properties;
using System;
using System.Collections.Generic;
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
            client.OnFailedToConnectToServer += OnFailedToConnectToServer;
        }

        private void PopulateOnlineUsers(List<User> users)
        {
            client.onlineUsers = users;

            if (onlineUsers.InvokeRequired)
            {
                Invoke(new Action(() => { onlineUsers.Items.Clear(); }));
            }
            else
            {
                onlineUsers.Items.Clear();
            }

            foreach (var user in users)
            {
                ListViewItem lvi = new ListViewItem(user.Username);
                if (onlineUsers.InvokeRequired)
                {
                    Invoke(new Action(() => { onlineUsers.Items.Add(lvi); }));
                }
                else
                {
                    onlineUsers.Items.Add(lvi);
                }
            }
        }

        private void OnDisconnectedFromServer()
        {
            if (connectButton.InvokeRequired)
            {
                Invoke(new Action(() => {
                    connectButton.Enabled = true;
                    pictureBox1.Image = Resources.DisconIco;
                    disconnectButton.Enabled = false;
                    messageButton.Enabled = false;
                    onlineUsers.Items.Clear();
                    listView1.Items.Clear();
                    connectionStatus.Text = "Disconnected";
                }));
            }
            else
            {
                connectButton.Enabled = true;
                pictureBox1.Image = Resources.DisconIco;
                disconnectButton.Enabled = false;
                messageButton.Enabled = false;
                onlineUsers.Items.Clear();
                listView1.Items.Clear();
                connectionStatus.Text = "Disconnected";
            }


        }

        private void UpdateMessages(Message msg)
        {
            var lvi = new ListViewItem(new string[] { msg.User.Username, msg.Content });
            Invoke(new Action(() => {
                listView1.Items.Add(lvi);
                listView1.Items[listView1.Items.Count - 1].EnsureVisible();
            }));
            ResizeListViewColumns(listView1);
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                Invoke(new Action(() =>
                {
                    column.Width = -2;
                }));
            }
        }

        private void OnConnectedToServer()
        {
            Invoke(new Action(() => {
                connectButton.Enabled = false;
                pictureBox1.Image = Resources.ConIco;
                this.ActiveControl = messageBox;
                this.AcceptButton = messageButton;
                disconnectButton.Enabled = true;
                messageButton.Enabled = true;
                connectButton.Text = "Connect";
                connectionStatus.Text = "Connected";
            }));
        }

        private void OnFailedToConnectToServer()
        {
            Invoke(new Action(() => {
                connectButton.Text = "Connect";
                connectionStatus.Text = "Connection Failed";
            }));
            MessageBox.Show("Failed to connect to server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            var timer = new System.Timers.Timer(5000);
            timer.Elapsed += (s, e) => connectButton_Click(null, null);
            timer.Start();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text == "Cancel")
            {
                client.Stop();
            }
            else
            {
                if (client.currentUser != null)
                {
                    Invoke(new Action(() => {
                        connectButton.Text = "Cancel";
                        connectionStatus.Text = "Connecting";
                    }));
                    client.Start();
                }
                else
                {
                    MessageBox.Show("Please login.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Login login = new Login(client);
                    login.ShowDialog();
                }
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            client.messageQueue.Add(new Message("discon", 0, client.currentUser.ID, "", client.currentUser, null));
        }

        private void MessageButton_Click(object sender, EventArgs e)
        {
            if (client.server.Connected)
            {
                client.messageQueue.Add(new Message("msg", 0, client.currentUser.ID, messageBox.Text, client.currentUser, null));
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


        private void OnlineUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem selectedIndex = onlineUsers.SelectedItems[0];
            User user = client.onlineUsers.Find(x => x.Username == selectedIndex.Text);
            DirectMessage dm = new DirectMessage(user, client);
            dm.ShowDialog();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Login login = new Login(client);
            login.ShowDialog();
        }
    }
}
