using System;
using System.Collections.Generic;

namespace ChatApp.Library
{
    [Serializable]
    public class Message
    {
        public Message(string type, int toID, int fromID, string content, User user, List<User> onlineUsers)
        {
            Type = type;
            ToID = toID;
            FromID = fromID;
            Content = content;
            User = user;
            this.onlineUsers = onlineUsers;
        }

        public string Type { get; set; }
        public int ToID { get; set; }
        public int FromID { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public List<User> onlineUsers { get; set; }
    }
}