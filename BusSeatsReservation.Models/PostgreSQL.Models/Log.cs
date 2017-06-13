using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.PostgreSQL.Models
{
    public class Log
    {
        public Log()
        {

        }

        [Key]
        public int Id { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime toDate { get; set; }
    }
}
