using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class NumbericsValidatorFactory
    {
        public virtual INumbericsValidator Create(params string[] numbers)
        {
            return new NumbericsValidator();
        }
    }
}
