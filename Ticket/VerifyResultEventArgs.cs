using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class VerifyResultEventArgs : EventArgs
    {
        public VerifyResultEventArgs(bool isSuccess)
        {
            this.IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; private set; }
    }
}
