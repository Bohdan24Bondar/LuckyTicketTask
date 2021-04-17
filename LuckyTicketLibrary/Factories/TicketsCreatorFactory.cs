using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class TicketsCreatorFactory
    {
        #region Private

        private int _numbericsCount;
        private int _startRange;
        private int _finishRange;

        #endregion

        public TicketsCreatorFactory(int numbericsCount, int startRange, int finishRange)
        {
            _numbericsCount = numbericsCount;
            _startRange = startRange;
            _finishRange = finishRange;
        }

        public virtual ITicketsCreator Create()
        {
            return new TicketsCreator(_numbericsCount, _startRange, _finishRange);
        }
    }
}
