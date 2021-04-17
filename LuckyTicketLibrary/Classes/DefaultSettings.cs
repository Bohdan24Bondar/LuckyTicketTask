using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class DefaultSettings
    {
        public const int DIVIDER = 2;
        public const string MOSKOW_CONDITION = "Moskow";
        public const string PITER_CONDITION = "Piter";
        public const string PATH_TO_FILE = "..\\Condition.txt";
        public const int MAX_TICKET_NUMBER = 999999;
        public const int NUMBERICS_COUNT = 6;
        public const string INSTRUCTION = "You should input 3 parameters\n" +
                "1 - condition for count\n" +
                "Codition must be \"Moskow\" or \"Piter\"\n" +
                "2 - start range of tickets number from 1\n" +
                "3 - finish range of tickets number to 999999";
    }
}
