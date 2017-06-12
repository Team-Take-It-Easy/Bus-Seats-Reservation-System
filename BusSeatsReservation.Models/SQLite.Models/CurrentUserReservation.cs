using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserReservation
    {
        public CurrentUserReservation()
        {

        }

        public int Id { get; set; }

        [Required]
        public virtual CurrentUserTrip Trip { get; set; }

        public virtual CurrentUserSeat Seat { get; set; }
    }
}
