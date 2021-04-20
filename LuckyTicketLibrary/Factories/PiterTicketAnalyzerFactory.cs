using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class PiterTicketAnalyzerFactory : LuckyTicketAnalyzerFactory
    {
        public override ILuckyTicketAnalyzer Create(IEnumerable<ITicket> tickets)
        {
            return new PiterLuckyTicketsAnalyzer(tickets);
        }
    }
}
