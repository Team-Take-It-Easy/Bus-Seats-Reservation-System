using System.ComponentModel.DataAnnotations;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Seat
    {
        public Seat() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Label { get; set; }
    }
}
