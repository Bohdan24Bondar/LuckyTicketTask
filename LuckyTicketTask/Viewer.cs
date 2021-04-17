using LuckyTicketLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketTask
{
    class Viewer
    {
        public void ShowLuckyTickets(IEnumerable<ITicket> tickets, int ticketCount)
        {
            Console.WriteLine("Count of lucky tickets = {0}", ticketCount);
            Console.WriteLine("Lucky tickets have next numbers:");

            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket.Number);
            }
        }

        public void ShowInstruction(string instruction)
        {
            Console.Clear();
            Console.WriteLine(instruction);
            Console.ReadKey();
        }
    }
}
