﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTicketLibrary
{
    public class ConditionReader
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
                try
                {
                    condition = reader.ReadLine();
                }
                catch (IOException)
                {
                    throw;
                }
            }

            return condition;
        }
    }
}