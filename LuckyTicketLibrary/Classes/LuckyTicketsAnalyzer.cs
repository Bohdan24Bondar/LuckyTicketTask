using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    internal abstract class LuckyTicketsAnalyzer
    {
        #region Consts

        public const int DIVIDER = 2;

        #endregion

        #region Private

        private readonly IEnumerable<ITicket> _tickets;

        #endregion

        public LuckyTicketsAnalyzer(IEnumerable<ITicket> tickets)
        {
            _tickets = tickets;
        }

        public int LickyTicketsCount { get; protected set; }

        public abstract bool IsLuckyTicket(string number);

        public virtual IEnumerable<ITicket> SearchLuckyTickets() 
        {
            Queue<ITicket> luckyTikcketsBasket = new Queue<ITicket>();

            //for (int i = 0; i < _tickets.Count; i++)
            //{
            //    if (IsLuckyTicket(_tickets[i].Number))
            //    {
            //        LickyTicketsCount++;
            //        luckyTikcketsBasket.Enqueue(_tickets[i]);
            //    }
            //}

            foreach (var ticket in _tickets)
            {
                if (IsLuckyTicket(ticket.Number))
                {
                    LickyTicketsCount++;
                    luckyTikcketsBasket.Enqueue(ticket);
                }
            }

            return luckyTikcketsBasket;
        }
    }
}
