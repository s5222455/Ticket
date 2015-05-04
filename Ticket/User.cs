using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ticket
{
    public class User
    {
        public User()
        {
        }

        public User(string uname, string upwd)
        {
            this.Username = uname;
            this.Password = upwd;
            passengers = new List<Passenger>();
        }

        private string username;
        private string password;
        private bool isSavePassword;
        private string nickName;
        private List<Passenger> passengers;

        public string Username { get { return username; } set { username = value; } }

        public string Password { get { return password; } set { password = value; } }
        [System.Xml.Serialization.XmlIgnore]
        public string NickName { get { return nickName; } set { nickName = value; } }

        public bool IsSavePassword { get { return isSavePassword; } set { isSavePassword = value; } }
        [System.Xml.Serialization.XmlIgnore]
        public List<Passenger> Passengers { get { return passengers; } set { passengers = value; } }

        internal void AddPassenger(Passenger p)
        {
            if (Passengers == null)
            {
                Passengers = new List<Passenger>();
            }

            if (Passengers.Exists((peg) => { return p.passenger_id_no == peg.passenger_id_no; }))
            {
                Passengers.Add(p);
            }
        }

        internal void RemovePassenger(string pid)
        {
            if (Passengers == null)
                return;

            try
            {
                var selectPassenger = (from p in Passengers where p.passenger_id_no == pid select p).SingleOrDefault();

                Passengers.Remove(selectPassenger);
            }
            catch
            {

            }
        }

        internal void RemovePassengerRange(Passenger[] passengerArray)
        {
            if (this.Passengers == null || passengerArray == null)
                return;

            foreach (var p in passengerArray)
            {
                RemovePassenger(p.passenger_id_no);
            }
        }
    }
}
