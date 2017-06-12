using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserRoute
    {
        public CurrentUserRoute()
        {

        }

        public int Id { get; set; }

        [Required]
        public CurrentUserDestination FromDestination { get; set; }

        [Required]
        public CurrentUserDestination ToDestination { get; set; }

        public DateTime DayOfWeek { get; set; }

        public DateTime DepatureHour { get; set; }

        public decimal? Price { get; set; }

        public CurrentUserBus Bus { get; set; }
    }
}
