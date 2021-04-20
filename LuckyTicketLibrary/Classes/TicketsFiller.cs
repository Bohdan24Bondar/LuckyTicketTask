using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    internal class TicketsFiller : ITicketsFiller
    {
        public TicketsFiller(int numbericsCount, int startRange, int finishRange)
        {
            NumbericsCount = numbericsCount;
            StartRange = startRange;
            FinishRange = finishRange;
        }

        public int NumbericsCount { get; private set; }

        public int StartRange { get; private set; }

        public int FinishRange { get; private set; }

        private int StartZeroCount(int number)
        {
            return NumbericsCount - number.ToString().Length;
        }

        public IEnumerable<ITicket> GetTickets()
        {
            List<ITicket> plentyTickets = new List<ITicket>(FinishRange - StartRange);

            for (int ticketNumber = StartRange; ticketNumber < FinishRange; ticketNumber++)
            {
                if (ticketNumber.ToString().Length < NumbericsCount)
                {
                    string zeros = string.Empty;
                    zeros = zeros.PadLeft(StartZeroCount(ticketNumber), '0');
                    string number = string.Format("{0}{1}", zeros, ticketNumber);
                    plentyTickets.Add(new Ticket(number));
                }
                else
                {
                    plentyTickets.Add(new Ticket(ticketNumber.ToString()));
                }
            }

            return plentyTickets;
        }     
    }
}
