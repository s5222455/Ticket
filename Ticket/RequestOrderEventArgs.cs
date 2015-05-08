using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class RequestOrderEventArgs : EventArgs
    {
        public RequestOrderEventArgs(TicketInfo ticketInfo)
        {
            this.TicketInfo = ticketInfo;
        }

        public TicketInfo TicketInfo { get; private set; }
    }
}
