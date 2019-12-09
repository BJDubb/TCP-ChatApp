using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Server
{
    class Program
    {
        static void Main()
        {
            Server server = new Server { running = true };
            Console.ReadLine();
        }
    }
}
