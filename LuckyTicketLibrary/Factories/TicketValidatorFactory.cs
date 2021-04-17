using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class TicketValidatorFactory
    {
        #region Private

        private string _condition;
        private int _startRange;
        private int _finishRange;

        #endregion

        public TicketValidatorFactory(string condition, int startRange, int finishRange)
        {
            _condition = condition;
            _startRange = startRange;
            _finishRange = finishRange;
        }

        internal TicketValidator TicketValidator
        {
            get => default;
            set
            {
            }
        }

        public virtual ITicketValidator Create()
        {
            return new TicketValidator(_condition, _startRange, _finishRange);
        }
    }
}
