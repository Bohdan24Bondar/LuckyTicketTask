using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicketLibrary
{
    interface ITicket
    {
        string Number { get; }

        bool IsLickyTicket { get; }
    }
}
