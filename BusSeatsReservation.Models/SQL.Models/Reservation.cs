using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Models.SQL.Models
{
    public class Reservation
    {
        public Reservation(decimal price, DateTime date)
        {
            this.Price = price;
            this.Date = date;
        }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }        

        // destination, date of departure, date of arrival, number of seats/tickets
    }
}
