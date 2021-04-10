using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    abstract class LuckyTicketsAnalyzer
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

        public virtual Queue<Ticket> SearchLickyTickets() 
        {
            Queue<Ticket> _luckyTikcketsBasket = new Queue<Ticket>();

            for (int i = 0; i < _tickets.Count; i++)
            {
                if (IsLuckyTicket(_tickets[i].Number))
                {
                    LickyTicketsCount++;
                    _luckyTikcketsBasket.Enqueue(_tickets[i]);
                }
            }

            return _luckyTikcketsBasket;
        }
    }
}
