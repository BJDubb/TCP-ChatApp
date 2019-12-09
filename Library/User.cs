using System;
using System.Collections.Generic;

namespace ChatApp.Library
{
    [Serializable]
    public class User
    {
        public static User Server = new User(0, "SERVER");
        public User(int iD, string username)
        {
            ID = iD;
            Username = username;
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public List<Message> Messages { get; set; }
    }
}
