using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuckyTicketLibrary;

namespace LuckyTicketTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleController application = new ConsoleController(DefaultSettings.PATH_TO_FILE, "1", "5000");
            application.Run();
            Console.ReadKey();
        }
    }
}
