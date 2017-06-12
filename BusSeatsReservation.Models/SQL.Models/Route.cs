using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Route
    {
        private ICollection<Bus> buses;

        public Route()
        {
            this.Buses = new HashSet<Bus>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Destination FromDestination { get; set; }

        [Required]
        public virtual Destination ToDestination { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [DataType(DataType.Time)]
        public DateTime DepatureHour { get; set; }

        public decimal? Price { get; set; }

        public virtual ICollection<Bus> Buses
        {
            get
            {
                return this.buses;
            }

            set
            {
                this.buses = value;
            }
        }
    }
}
