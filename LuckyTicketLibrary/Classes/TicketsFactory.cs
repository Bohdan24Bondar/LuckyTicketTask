using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    class TicketsFactory
    {
        #region Private

        private int _startRange;
        private int _finishRange;

        #endregion

        public TicketsFactory(int numbericsCount, int startRange, int finishRange)
        {
            NumbericsCount = numbericsCount;
            _startRange = startRange;
            _finishRange = finishRange;
        }

        public int StartZeroCount(int number)
        {
            return NumbericsCount - number.ToString().Length;
        }

        public int NumbericsCount { get; private set; }

        public List<Ticket> CrearyTickets()
        {
            List<Ticket> _plentyTickets = new List<Ticket>(_startRange - _finishRange);

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
