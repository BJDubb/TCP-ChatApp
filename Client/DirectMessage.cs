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
    public partial class DirectMessage : Form
    {
        public Client client = null;
        public User user;
        public DirectMessage(User user, Client client)
        {
            InitializeComponent();
            this.user = user;
            username.Text = user.Username;
            this.client = client;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            client.messageQueue.Add(new Message("msg", user.ID, client.currentUser.ID, textBox.Text, client.currentUser, null));
        }
    }
}
