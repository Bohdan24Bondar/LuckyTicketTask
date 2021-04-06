using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    public class LickyTicketEventArgs : EventArgs
    {
        public LickyTicketEventArgs(string number, int countLickyTikets)
        {
            Number = number;
            CountLickyTikets = countLickyTikets;
        }

        public string Number { get; private set; }

        public int CountLickyTikets { get; private set; }
    }
}
