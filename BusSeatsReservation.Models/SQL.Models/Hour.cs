using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Hour
    {
        public Hour() { }

        public int Id { get; set; }

        public DateTime StartHour { get; set; }
    }
}
