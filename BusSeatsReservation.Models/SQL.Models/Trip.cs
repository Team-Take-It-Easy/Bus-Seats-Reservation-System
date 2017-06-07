using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Trip
    {
        public Trip() { }

        private ICollection<Reservation> reservations;

        [Key]
        public int Id { get; set; }

        [Required]
        public Route Route { get; set; }

        [Required]
        public Bus Bus { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<Reservation> Reservations
        {
            get
            {
                return this.reservations;
            }

            set
            {
                this.reservations = value;
            }
        }
    }
}
