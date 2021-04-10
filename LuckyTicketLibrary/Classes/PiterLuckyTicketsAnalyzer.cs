using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    class PiterLuckyTicketsAnalyzer : LuckyTicketsAnalyzer
    {
        public PiterLuckyTicketsAnalyzer(List<Ticket> tickets)
            : base(tickets)
        {

        }   

        public override bool IsLuckyTicket(string number)
        {
            int evenSum = 0;
            int oddSum = 0;

            for (int index = 0; index < number.Length; index++)
            {
                if ((number[index] % DIVIDER) == 0)
                {
                    evenSum += number[index] - '0';
                }
                else
                {
                    oddSum += number[index] - '0';
                }
            }

            return evenSum == oddSum;
        }
    }
}
