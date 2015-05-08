using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ticket
{
    public class VerifyEventArgs : EventArgs
    {
        public VerifyEventArgs(VerifyMode mode, Image image)
        {
            this.VerifyMode = mode;
            this.VerifyImage = image;
            this.VerifyCode = string.Empty;
        }

        public VerifyMode VerifyMode { get; private set; }

        public Image VerifyImage { get; private set; }

        public string VerifyCode { get; set; }
    }

    public enum VerifyMode
    {
        Login,
        VerifyError,
        Order,
        Passenger,
    }
}
