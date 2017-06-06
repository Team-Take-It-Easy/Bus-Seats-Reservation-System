using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Data;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Models.SQL.Models;
using BusSeatsReservation.Data.Common.DataProviders;
using BusSeatsReservation.Models.PostgreSQL.Models;
using BusSeatsReservation.Data.PostgreSQL;

namespace BusSeatsReservation.Client
{
    public class Program
    {
        public static void Main()
        {
            var sqlDbContext = new SQLDbContext();

            var user = new User("FirstName", "LastName");

            var reservation = new Reservation(10, DateTime.Now);

            user.Reservations.Add(reservation);

            sqlDbContext.Users.Add(user);
            sqlDbContext.Reservations.Add(reservation);


            sqlDbContext.SaveChanges();

            // with Repository

            var usersRepository = new SQLRepository<User>(sqlDbContext);
            var reservationsRepository = new SQLRepository<Reservation>(sqlDbContext);

            Console.WriteLine(usersRepository.GetByID(1).FirstName);
            Console.WriteLine(reservationsRepository.GetByID(1).Date);

            // with Repository and UnitOfWork

            var sqlUnitOfWork = new EfUnitOfWork(sqlDbContext);

            var sqlDataProvider = new SQLDataProvider(sqlUnitOfWork, usersRepository, reservationsRepository);

            var newUser = new User("Pesho", "Ivanov");
            var newReservation = new Reservation(20, DateTime.Now);

            newUser.Reservations.Add(newReservation);

            Console.WriteLine("-------------------using sqlDataProvider---------------------");

            sqlDataProvider.UsersRepository.Add(newUser);
            sqlDataProvider.ReservationsRepository.Add(newReservation);

            sqlDataProvider.UnitOfWork.Commit();

            Console.WriteLine(sqlDataProvider.UsersRepository.GetByID(2).FirstName);
            Console.WriteLine(sqlDataProvider.ReservationsRepository.GetByID(2).Price);

            // PostgreSQL Data provider

            var postgreSQLDbContext = new PostgreSQLDbContext();
            var busesRepository = new SQLRepository<Bus>(postgreSQLDbContext);

            var postgreSQLUnitOfWork = new EfUnitOfWork(postgreSQLDbContext);

            var postgreSQLDataProvider = new PostgreSQLDataProvider(postgreSQLUnitOfWork, busesRepository);

            var bus = new Bus("CA 1234 BP", 1);

            postgreSQLDataProvider.BusesRepository.Add(bus);

            postgreSQLDataProvider.UnitOfWork.Commit();

            Console.WriteLine("-------------------using PostgreSQLProvider---------------------");

            Console.WriteLine(postgreSQLDataProvider.BusesRepository.GetByID(1).RegistrationNumber);
        }
    }
}
