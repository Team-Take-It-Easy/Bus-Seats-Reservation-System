using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserTrip
    {
        public CurrentUserTrip()
        {

        }

        public int Id { get; set; }

        [Required]
        public CurrentUserRoute Route { get; set; }

        [Required]
        public CurrentUserBus Bus { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public CurrentUserReservation reservation { get; set; }
    }
}
