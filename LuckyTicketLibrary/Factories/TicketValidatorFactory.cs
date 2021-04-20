using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class TicketValidatorFactory
    {
        public virtual ITicketValidator Create(string condition, int startRange, int finishRange)
        {
            return new TicketValidator(condition, startRange, finishRange);
        }
    }
}
