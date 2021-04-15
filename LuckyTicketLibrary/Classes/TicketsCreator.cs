using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class TicketsCreator
    {
        #region Private

        private int _startRange;
        private int _finishRange;

        #endregion

        public TicketsCreator(int numbericsCount, int startRange, int finishRange)
        {
            NumbericsCount = numbericsCount;
            _startRange = startRange;
            _finishRange = finishRange;
        }

        public int NumbericsCount { get; private set; }

        private int StartZeroCount(int number)
        {
            return NumbericsCount - number.ToString().Length;
        }

        public List<Ticket> FillTickets()
        {
            List<Ticket> _plentyTickets = new List<Ticket>(_finishRange - _startRange);

            for (int ticketNumber = _startRange; ticketNumber < _finishRange; ticketNumber++)
            {
                if (ticketNumber.ToString().Length < NumbericsCount)
                {
                    string zeros = string.Empty;
                    zeros = zeros.PadLeft(StartZeroCount(ticketNumber), '0');
                    string number = string.Format("{0}{1}", zeros, ticketNumber);
                    _plentyTickets.Add(new Ticket(number));
                }
                else
                {
                    _plentyTickets.Add(new Ticket(ticketNumber.ToString()));
                }
            }

            return _plentyTickets;
        }     
    }
}
