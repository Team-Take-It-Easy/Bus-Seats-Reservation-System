using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Reservation
    {

        public Reservation() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public Trip Trip { get; set; }

        public Seat Seat { get; set; }

        public User User { get; set; }
    }
}
