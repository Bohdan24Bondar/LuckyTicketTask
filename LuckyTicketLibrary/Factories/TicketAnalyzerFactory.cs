using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public abstract class TicketAnalyzerFactory
    {
        protected readonly List<ITicket> _tickets;

        public TicketAnalyzerFactory(List<ITicket> tickets)
        {
            _tickets = tickets;
        }

        public abstract ITicketAnalyzer Create();
    }
}
