using BusSeatsReservation.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Bus
    {
        private ICollection<Route> routes;
        private ICollection<Seat> seats;

        public Bus()
        {
            this.Routes = new HashSet<Route>();
            this.Seats = new HashSet<Seat>();
        }

        public Bus(BusType type, int numberOfSeats, string regNumber)
        {
            this.Type = type;
            this.NumberOfSeats = numberOfSeats;
            this.RegNumber = regNumber;
            this.Routes = new HashSet<Route>();
            this.Seats = new HashSet<Seat>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public BusType Type { get; set; }

        [Required]
        [Range(10, 99)]
        public int NumberOfSeats { get; set; }

        public string RegNumber { get; set; }

        public virtual ICollection<Route> Routes
        {
            get
            {
                return this.routes;
            }

            set
            {
                this.routes = value;
            }
        }

        public virtual ICollection<Seat> Seats
        {
            get
            {
                return this.seats;
            }

            set
            {
                this.seats = value;
            }
        }
    }
}
