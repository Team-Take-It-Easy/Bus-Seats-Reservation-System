using BusSeatsReservation.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Bus
    {
        public Bus()
        {

        }

        public Bus(BusType type, int numberOfSeats, string regNumber)
        {
            this.Type = type;
            this.NumberOfSeats = numberOfSeats;
            this.RegNumber = regNumber;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public BusType Type { get; set; }

        [Required]
        [Range(10, 99)]
        public int NumberOfSeats { get; set; }

        [Required]
        public string RegNumber { get; set; }
    }
}
