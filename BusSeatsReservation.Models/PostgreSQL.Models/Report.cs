using System;
using System.ComponentModel.DataAnnotations;

namespace BusSeatsReservation.Models.PostgreSQL.Models
{
    public class Report
    {
        public Report()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
