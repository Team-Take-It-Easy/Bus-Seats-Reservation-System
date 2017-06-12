using BusSeatsReservation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class CurrentUserBus
    {
        public CurrentUserBus()
        {

        }

        public int Id { get; set; }

        [Required]
        public BusType Type { get; set; }

        public string RegNumber { get; set; }
    }
}
