using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class ReponseEventArgs<T> : EventArgs where T : Result
    {
        public ReponseEventArgs(T result)
        {
            this.Result = result;
        }

        public T Result { get; private set; }
    }
}
