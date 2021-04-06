using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class Ticket : ITicket
    {
        public Ticket(string number)
        {
            Number = number;
        }

        public string Number { get; protected set; }

        protected string LeftSide
        {
            get
            {
                return Number.Substring(0, SideLength);
            }
        }

        protected string RightSide
        {
            get
            {
                return Number.Substring(SideLength, Number.Length);
            }
        }

        protected int SideLength
        {
            get
            {
                return Number.Length / 2; //todo
            }
        }

        public bool IsLickyTicket
        {
            get
            {
                return int.Parse(LeftSide) == int.Parse(RightSide);
            }
        }
    }
}
