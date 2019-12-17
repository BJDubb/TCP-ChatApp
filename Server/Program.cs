using ChatApp.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Server
{
    class Program
    {
        static Server server = null;
        static void Main()
        {
            server = new Server { running = true };
            Thread thread = new Thread(new ThreadStart(GetInput));
            thread.Start();
        }

        private static void GetInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string command = input.Split(' ')[0];
                
                switch (command)
                {
                    case "say":
                        string args = input.Substring(command.Length + 1, input.Length - command.Length - 1);
                        foreach (var c in server.clients)
                        {
                            c.messageQueue.Add(new Message("msg", 0, User.Server.ID, args, User.Server, null)); ;
                        }
                        server.Log(args, User.Server);
                        break;
                    case "stop":
                        server.Stop();
                        break;
                    default:
                        Console.WriteLine("INVALID COMMAND");
                        break;
                }
            }
        }
    }
}
