using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.PostgreSQL.Models
{
    public class BusPG
    {
        //private ICollection<Reservation> reservations;

        public BusPG()
        {
            //this.reservations = new HashSet<Reservation>();
        }

        public BusPG(string registrationNumber, int reservationId)
        {
            //this.reservations = new HashSet<Reservation>();
            this.RegistrationNumber = registrationNumber;
            this.ReservationId = reservationId;
        }

        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public int ReservationId { get; set; }

        /*
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
        */
        // destination, country, city, ...
    }
}
