using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class ConditionReaderFactory
    {
        public virtual IConditionReader Create(string pathToFile)
        {
            return new ConditionReader(pathToFile);
        }
    }
}
