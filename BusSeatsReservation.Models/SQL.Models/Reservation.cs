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
        public virtual Trip Trip { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual User User { get; set; }
    }
}
