using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class Ticket 
    {
        public Ticket(string number)
        {
            Number = number;
        }

        public string Number { get; private set; }
    }
}
