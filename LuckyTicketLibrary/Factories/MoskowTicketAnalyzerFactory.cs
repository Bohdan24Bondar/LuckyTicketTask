using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class MoskowTicketAnalyzerFactory : TicketAnalyzerFactory
    {
        public MoskowTicketAnalyzerFactory(List<ITicket> tickets)
            : base(tickets)
        {

        }

        public override ITicketAnalyzer Create()
        {
            return new MoskowLuckyTicketsAnalyzer(_tickets);
        }
    }
}
