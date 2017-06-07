using BusSeatsReservation.Models.PostgreSQL.Models;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Bus
    {
        public Bus(BusType type, int numberOfSeats)
        {
            this.Type = type;
            this.NumberOfSeats = numberOfSeats;
        }

        public int Id { get; set; }

        public BusType Type { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
