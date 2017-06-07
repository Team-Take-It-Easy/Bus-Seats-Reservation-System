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

            var sqlUnitOfWork = new EfUnitOfWork(sqlDbContext);

            var sqlDataProvider = new SQLDataProvider(sqlUnitOfWork, usersRepository, reservationsRepository);

            var newUser = new User("user2", "Pesho", "Ivanov");


            Console.WriteLine("-------------------using sqlDataProvider---------------------");

            sqlDataProvider.UsersRepository.Add(newUser);

            sqlDataProvider.UnitOfWork.Commit();

            Console.WriteLine(sqlDataProvider.UsersRepository.GetByID(2).FirstName);

            // PostgreSQL Data provider

            var postgreSQLDbContext = new PostgreSQLDbContext();
            var busesRepository = new SQLRepository<BusTypePG>(postgreSQLDbContext);

            var postgreSQLUnitOfWork = new EfUnitOfWork(postgreSQLDbContext);

            var postgreSQLDataProvider = new PostgreSQLDataProvider(postgreSQLUnitOfWork, busesRepository);

            var busType = new BusTypePG("Standard");

            postgreSQLDataProvider.BusesRepository.Add(busType);

            postgreSQLDataProvider.UnitOfWork.Commit();

            Console.WriteLine("-------------------using PostgreSQLProvider---------------------");

            //Console.WriteLine(postgreSQLDataProvider.BusesRepository.GetByID(1).RegistrationNumber);

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
        }
    }
}
