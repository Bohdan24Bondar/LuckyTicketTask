using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class TicketsFillerFactory
    {
        public virtual ITicketsFiller Create(int numbericsCount, int startRange, int finishRange)
        {
            return new TicketsFiller(numbericsCount, startRange, finishRange);
        }
    }
}
