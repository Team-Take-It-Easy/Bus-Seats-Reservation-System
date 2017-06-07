using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Route
    {
        public Route() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public Destination FromDestination { get; set; }

        [Required]
        public Destination ToDestination { get; set; }

        public DateTime DayOfWeek { get; set; }

        public DateTime DepatureHour { get; set; }

        public decimal? Price { get; set; }
    }
}
