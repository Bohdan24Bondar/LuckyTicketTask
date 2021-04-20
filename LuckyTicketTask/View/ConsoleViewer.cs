using LuckyTicketLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketTask
{
    class ConsoleView : IViewer
    {
        #region Constants

        public const string COUNT_MESSAGE = "Count of lucky tickets =";
        public const string NUMBER_MESSAGE = "Lucky tickets have next numbers:";

        #endregion

        public void ShowLuckyTickets(IEnumerable<ITicket> tickets, int ticketCount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} {1}", COUNT_MESSAGE, ticketCount);
            Console.WriteLine(NUMBER_MESSAGE);

            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket.Number);
            }
        }

        public void ShowMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
