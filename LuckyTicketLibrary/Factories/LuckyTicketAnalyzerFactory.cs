using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public abstract class LuckyTicketAnalyzerFactory
    {
        public abstract ILuckyTicketAnalyzer Create(IEnumerable<ITicket> tickets);
    }
}
