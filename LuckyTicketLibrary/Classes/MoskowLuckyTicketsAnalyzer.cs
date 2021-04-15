using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class MoskowLuckyTicketsAnalyzer : LuckyTicketsAnalyzer
    {
        public MoskowLuckyTicketsAnalyzer(List<Ticket> tickets)
            : base(tickets)
        {

        }

        public override bool IsLuckyTicket(string number)
        {
            int leftSide = 0;
            int rightSide = 0;
            int sideLenght = number.Length / DIVIDER;

            for (int index = 0; index < number.Length; index++)
            {
                if (sideLenght > index)
                {
                    leftSide += number[index] - '0';
                }
                else
                {
                    rightSide += number[index] - '0';
                }
            }

            return leftSide == rightSide;
        }
    }
}
