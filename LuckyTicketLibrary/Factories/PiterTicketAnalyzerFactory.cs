using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class PiterTicketAnalyzerFactory : TicketAnalyzerFactory
    {
        public PiterTicketAnalyzerFactory(List<ITicket> tickets)
            : base(tickets)
        {

        }

        public override ITicketAnalyzer Create()
        {
            return new PiterLuckyTicketsAnalyzer(_tickets);
        }
    }
}
