using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public interface ILuckyTicketAnalyzer
    {
        int LickyTicketsCount { get; }
        
        bool IsLuckyTicket(string number);

        IEnumerable<ITicket> GetLuckyTickets();
    }
}
