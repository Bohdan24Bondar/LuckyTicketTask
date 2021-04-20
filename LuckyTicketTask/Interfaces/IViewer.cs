using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuckyTicketLibrary;

namespace LuckyTicketTask
{
    public interface IViewer 
    {
        void ShowLuckyTickets(IEnumerable<ITicket> tickets, int ticketCount);

        void ShowMessage(string message);
    }
}
