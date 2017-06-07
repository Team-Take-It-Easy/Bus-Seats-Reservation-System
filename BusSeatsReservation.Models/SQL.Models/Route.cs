using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Route
    {
        private ICollection<Seat> seats;

        public Route() { }

        public int Id { get; set; }

        public Destination StartFrom { get; set; }

        public Destination GoingTo { get; set; }

        public Day Date { get; set; }

        public Hour DepatureHour { get; set; }

        public Bus Bus { get; set; }

        public virtual ICollection<Seat> Seats
        {
            get { return this.seats; }
            set { this.seats = value; }
        }
    }
}
