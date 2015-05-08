using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class SessionEventArgs : EventArgs
    {
        public SessionEventArgs(int state)
        {
            this.State = state;
        }

        public int State { get; private set; }
    }
}
