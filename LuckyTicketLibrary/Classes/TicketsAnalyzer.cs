using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    class TicketsAnalyzer
    {
        #region Private

        private readonly List<ITicket> _tickets;
        private event LuckyTicketNotifyer __ticketNotifyer;

        #endregion

        public TicketsAnalyzer(List<ITicket> tickets)
        {
            _tickets = tickets;
        }

        public int LickyTicketsCount { get; private set; }

        public event LuckyTicketNotifyer Counter
        {
            add
            {
                __ticketNotifyer += value;
            }
            remove
            {
                __ticketNotifyer -= value;
            }
        }

        public Queue<ITicket> SearchLickyTickets() 
        {
            Queue<ITicket> _luckyTikcketsBasket = new Queue<ITicket>();

            for (int i = 0; i < _tickets.Count; i++)
            {
                if (_tickets[i].IsLickyTicket)
                {
                    LickyTicketsCount++;
                    _luckyTikcketsBasket.Enqueue(_tickets[i]);
                    __ticketNotifyer?.Invoke(this, new LickyTicketEventArgs(_tickets[i].Number,
                            LickyTicketsCount));
                }
            }

            return _luckyTikcketsBasket;
        }
    }
}
