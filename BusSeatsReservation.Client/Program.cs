using BusSeatsReservation.Data;
using BusSeatsReservation.Models.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Client
{
    public class Program
    {
        public static void Main()
        {
            var sqlDbContext = new SQLDbContext();

            var user = new User("FirstName", "LastName");

            var reservation = new Reservation(10, new DateTime().Date);

            user.Reservations.Add(reservation);

            sqlDbContext.Users.Add(user);
            sqlDbContext.Reservations.Add(reservation);

            sqlDbContext.SaveChanges();


        }
    }
}
