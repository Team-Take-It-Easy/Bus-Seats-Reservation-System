using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserSeat
    {
        public CurrentUserSeat()
        {

        }

        public int Id { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public CurrentUserBus Bus { get; set; }
    }
}
