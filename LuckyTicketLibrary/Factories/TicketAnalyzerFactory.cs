using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public abstract class TicketAnalyzerFactory
    {
        protected readonly IEnumerable<ITicket> _tickets;

        public TicketAnalyzerFactory(IEnumerable<ITicket> tickets)
        {
            _tickets = tickets;
        }

        public abstract ITicketAnalyzer Create();
    }
}
