using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public abstract class LuckyTicketsAnalyzer
    {
        #region Consts

        public const int DIVIDER = 2;

        #endregion

        #region Private

        private readonly List<Ticket> _tickets;

        #endregion

        public LuckyTicketsAnalyzer(List<Ticket> tickets)
        {
            _tickets = tickets;
        }

        public int LickyTicketsCount { get; protected set; }

        public abstract bool IsLuckyTicket(string number);

        public virtual IEnumerable<Ticket> SearchLuckyTickets() 
        {
            Queue<Ticket> luckyTikcketsBasket = new Queue<Ticket>();

            for (int i = 0; i < _tickets.Count; i++)
            {
                if (IsLuckyTicket(_tickets[i].Number))
                {
                    LickyTicketsCount++;
                    luckyTikcketsBasket.Enqueue(_tickets[i]);
                }
            }

            return luckyTikcketsBasket;
        }
    }
}
