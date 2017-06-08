using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Data;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Models.SQL.Models;
using BusSeatsReservation.Models.PostgreSQL.Models;
using BusSeatsReservation.Data.PostgreSQL;
using BusSeatsReservation.Models.SQLite.Models;
using BusSeatsReservation.Data.SQLite;

namespace BusSeatsReservation.Client
{
    public class StartUp
    {
        public static void Main()
        {
            
            var sqlDbContext = new SQLDbContext();

            var user = new User("user1", "FirstName", "LastName");
            var destination = new Destination("Sofia");

            sqlDbContext.Users.Add(user);
            sqlDbContext.Destinations.Add(destination);

            sqlDbContext.SaveChanges();

            // with Repository

            var usersRepository = new SQLRepository<User>(sqlDbContext);
            var reservationsRepository = new SQLRepository<Reservation>(sqlDbContext);

            Console.WriteLine(usersRepository.GetByID(1).FirstName);

            // with Repository and UnitOfWork
            
            Console.WriteLine("-------------------SQL Repository and Unit Of Work ---------------------");

            // PostgreSQL with DbContext - ? TODO: make UnitOfWork

            var postgreSQLDbContext = new PostgreSQLDbContext();
            var busesRepository = new SQLRepository<BusTypePG>(postgreSQLDbContext);

            var postgreSQLUnitOfWork = new EfUnitOfWork(postgreSQLDbContext);

            var busType = new BusTypePG("Standard");

            busesRepository.Add(busType);

            postgreSQLDbContext.SaveChanges();

            Console.WriteLine("------------------- PostgreSQL Database ---------------------");

            Console.WriteLine(busesRepository.GetByID(1));

            Console.WriteLine("Unit of work");

            var newNewUser = new User("user3", "Gosho", "Peshov");
            var unitOfWork = new EfUnitOfWork(sqlDbContext);

            unitOfWork.UserRepository.Add(newNewUser);
            unitOfWork.Commit();
            //var usersArr = unitOfWork.UserRepository.GetAll();

            //foreach (var u in usersArr)
            //{
            //    Console.WriteLine($"First name: {u.FirstName}; Last name: {u.LastName}");
            //}
            
            // SQLite Connection - ? TODO: UnitOfWork
            var report = new Report("Test Report");

            var sqLiteDbContext = new SQLiteDbContext();

            var sqLiteRepository = new SQLRepository<Report>(sqLiteDbContext);

            sqLiteRepository.Add(report);

            sqLiteDbContext.SaveChanges();

            Console.WriteLine("------------------------SQLite Database-------------------------------");

            Console.WriteLine(sqLiteRepository.GetByID(1).Title);
        }
    }
}
