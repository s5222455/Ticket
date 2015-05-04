using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class CityEventArgs : EventArgs
    {
        public CityEventArgs(City[] cities)
        {
            this.Cities = cities;
        }

        public City[] Cities { get; private set; }
    }
}
