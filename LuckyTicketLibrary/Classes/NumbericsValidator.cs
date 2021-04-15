using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class NumbericsValidator
    {
        public bool IsNumber(params string [] numbers)
        {
            bool isNumber = true;

            for (int index = 0; index < numbers.Length; index++)
            {
                isNumber = int.TryParse(numbers[index], out _);

                if (!isNumber)
                {
                    return false;
                }
            }

            return isNumber;
        }
    }
}
