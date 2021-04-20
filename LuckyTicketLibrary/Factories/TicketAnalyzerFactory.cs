using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public abstract class TicketAnalyzerFactory
    {
        public abstract ITicketAnalyzer Create(IEnumerable<ITicket> tickets);
    }
}
