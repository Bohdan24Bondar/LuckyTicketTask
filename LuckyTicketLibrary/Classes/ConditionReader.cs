using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTicketLibrary
{
    internal class ConditionReader : IConditionReader
    {
        public ConditionReader(string pathToFile)
        {
            PathToFile = pathToFile;
        }

        public string PathToFile { get; private set; }

        public string GetCondition()
        {
            string condition = string.Empty;

            using (StreamReader reader = new StreamReader(PathToFile))
            {
                condition = reader.ReadLine();
            }

            return condition;
        }
    }
}
