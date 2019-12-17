using ChatApp.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Client
{
    public partial class Login : Form
    {
        Client client = null;
        User loggedInUser = null;
        public Login(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Authenticate();
        }

        private void Authenticate()
        {
            string html = string.Empty;
            string url = String.Format("http://bjdubb.com/ChatApp/login.php?username={0}&password={1}", textBox1.Text, textBox2.Text);

            Console.WriteLine(url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            switch (html)
            {
                case "1":
                    errorText.Text = "Connection Error";
                    break;
                case "2":
                    errorText.Text = "Connection Error";
                    break;
                case "3":
                    errorText.Text = "User does not exist";
                    break;
                case "4":
                    errorText.Text = "Invalid Password";
                    break;
                default:
                    var data = html.Split('\n');
                    loggedInUser = new User(System.Convert.ToInt32(data[1]), data[0]);
                    client.currentUser = loggedInUser;
                    this.Close();
                    break;
            }
        }
    }
}
