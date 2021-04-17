using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    internal class TicketValidator : ITicketValidator
    {
        public TicketValidator(string condition, int startRange, int finishRange)
        {
            Condition = condition;
            StartRange = startRange;
            FinishRange = finishRange;
        }

        public string Condition { get; private set; }

        public int StartRange { get; private set; }

        public int FinishRange { get; private set; }

        public bool IsRightCondition()
        {
            string trimmedCondition = Condition.Trim();
            return (trimmedCondition == DefaultSettings.MOSKOW_CONDITION)
                    || (trimmedCondition == DefaultSettings.PITER_CONDITION);
        }

        public bool IsFallenTheRange()
        {
            return (StartRange > 0) && (FinishRange <= DefaultSettings.MAX_TICKET_NUMBER);
        }

    }
}
