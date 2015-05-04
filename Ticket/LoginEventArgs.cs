using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; private set; }

        public string Message { get; private set; }
    }
}
