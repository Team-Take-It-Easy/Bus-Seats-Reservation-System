using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class User
    {
        private ICollection<Reservation> reservations;

        public User()
        {
            this.reservations = new HashSet<Reservation>();
        }

        public User(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Reservation> Reservations
        {
            get
            {
                return this.reservations;
            }

            set
            {
                this.reservations = value;
            }
        }
    }
}
