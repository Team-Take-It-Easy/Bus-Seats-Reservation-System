using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQLite.Models
{
    public class Report
    {
        public Report()
        {

        }

        public Report(string title)
        {
            this.Title = title;
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}
