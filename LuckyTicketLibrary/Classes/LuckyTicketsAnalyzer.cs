using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    internal abstract class LuckyTicketsAnalyzer : ITicketAnalyzer
    {
        #region Private

        private readonly IEnumerable<ITicket> _tickets;

        #endregion

        public LuckyTicketsAnalyzer(IEnumerable<ITicket> tickets)
        {
            _tickets = tickets;
        }

        public int LickyTicketsCount { get; protected set; }

        public TicketAnalyzerFactory TicketAnalyzerFactory
        {
            get => default;
            set
            {
            }
        }

        public abstract bool IsLuckyTicket(string number);

        public virtual IEnumerable<ITicket> SearchLuckyTickets() 
        {
            Queue<ITicket> luckyTikcketsBasket = new Queue<ITicket>();

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
