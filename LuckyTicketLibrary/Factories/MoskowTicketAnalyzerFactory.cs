using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class MoskowTicketAnalyzerFactory : TicketAnalyzerFactory
    {
        public override ITicketAnalyzer Create(IEnumerable<ITicket> tickets)
        {
            return new MoskowLuckyTicketsAnalyzer(tickets);
        }
    }
}
