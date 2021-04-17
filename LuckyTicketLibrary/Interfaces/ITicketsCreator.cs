using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public interface ITicketsCreator
    {
        IEnumerable<ITicket> GetTickets();
    }
}
