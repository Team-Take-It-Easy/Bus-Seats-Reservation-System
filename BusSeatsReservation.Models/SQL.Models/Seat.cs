using System.ComponentModel.DataAnnotations;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Seat
    {
        public Seat() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual string Label { get; set; }

        [Required]
        public virtual Bus Bus { get; set; }
    }
}
