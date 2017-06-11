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
using BusSeatsReservation.Data.Common.Factories;
using Newtonsoft.Json.Linq;
using System.IO;

namespace BusSeatsReservation.Client
{
    public class StartUp
    {
        public static void Main()
        {
            var sqlDbContext = new SQLDbContext();
            var repositoryFactory = new RepositoryFactory();

            var unitOfWork = new EfUnitOfWork(sqlDbContext, repositoryFactory);

            LoadInitialData(unitOfWork);

            //var user = new User("user1", "FirstName", "LastName");
            //var destination = new Destination("Sofia");

            //sqlDbContext.Users.Add(user);
            //sqlDbContext.Destinations.Add(destination);

            //sqlDbContext.SaveChanges();

            //// with Repository

            //var usersRepository = new SQLRepository<User>(sqlDbContext);
            //var reservationsRepository = new SQLRepository<Reservation>(sqlDbContext);

            //Console.WriteLine(usersRepository.GetByID(1).FirstName);

            //// with Repository and UnitOfWork
            
            //Console.WriteLine("-------------------SQL Repository and Unit Of Work ---------------------");

            //// PostgreSQL with DbContext - ? TODO: make UnitOfWork

            //var postgreSQLDbContext = new PostgreSQLDbContext();
            //var busesRepository = new SQLRepository<BusTypePG>(postgreSQLDbContext);

            //var postgreSQLUnitOfWork = new EfUnitOfWork(postgreSQLDbContext, repositoryFactory);

            //var busType = new BusTypePG("Standard");

            //busesRepository.Add(busType);

            //postgreSQLDbContext.SaveChanges();

            //Console.WriteLine("------------------- PostgreSQL Database ---------------------");

            ////Console.WriteLine(busesRepository.GetByID(1));

            //Console.WriteLine("Unit of work");

            //var newNewUser = new User("user3", "Gosho", "Peshov");

            //unitOfWork.UserRepository.Add(newNewUser);
            //unitOfWork.Commit();
            ////var usersArr = unitOfWork.UserRepository.GetAll();

            ////foreach (var u in usersArr)
            ////{
            ////    Console.WriteLine($"First name: {u.FirstName}; Last name: {u.LastName}");
            ////}


            //// testing Delete and Update methods

            //var newDestination = new Destination("Plovdiv");

            //unitOfWork.DestinationRepository.Add(newDestination);

            //unitOfWork.Commit();
            //var destinations = unitOfWork.DestinationRepository.GetAll();

            //foreach (var town in destinations)
            //{
            //    Console.WriteLine("Id: {0}, Name: {1}", town.Id, town.Name);
            //}

            //Console.WriteLine("-----Update---------");

            //newDestination.Name = "Varna";

            //unitOfWork.DestinationRepository.Update(newDestination);

            //destinations = unitOfWork.DestinationRepository.GetAll();

            //foreach (var town in destinations)
            //{
            //    Console.WriteLine("Id: {0}, Name: {1}", town.Id, town.Name);
            //}

            //Console.WriteLine("-------------Delete----------------");

            //unitOfWork.DestinationRepository.Delete(newDestination);

            //unitOfWork.Commit();

            //destinations = unitOfWork.DestinationRepository.GetAll();

            //foreach (var town in destinations)
            //{
            //    Console.WriteLine("Id: {0}, Name: {1}", town.Id, town.Name);
            //}

            //unitOfWork.Commit();

            //// SQLite Connection - ? TODO: UnitOfWork
            //var report = new Report("Test Report");

            //var sqLiteDbContext = new SQLiteDbContext();

            //var sqLiteRepository = new SQLRepository<Report>(sqLiteDbContext);

            //sqLiteRepository.Add(report);

            //sqLiteDbContext.SaveChanges();

            //Console.WriteLine("------------------------SQLite Database-------------------------------");

            //Console.WriteLine(sqLiteRepository.GetByID(1).Title);
        }

        public static void LoadInitialData(EfUnitOfWork unitOfWork)
        {
            string path = @"..\\..\\Data\buses_input.json";
            string json = File.ReadAllText(path);

            JObject allSearch = JObject.Parse(json);

            IList<JToken> destinationResults = allSearch["Destinations"].Children().ToList();
            IList<JToken> busResults = allSearch["Buses"].Children().ToList();
            IList<JToken> seatResults = allSearch["Seats"].Children().ToList();
            IList<JToken> userResults = allSearch["Users"].Children().ToList();
            //IList<JToken> routeResults = allSearch["Routes"].Children().ToList();

            Console.WriteLine("Load initial DESTINATION data ...");

            foreach (JToken result in destinationResults)
            {
                Destination destinationToAdd = result.ToObject<Destination>();
                unitOfWork.DestinationRepository.Add(destinationToAdd);
            }

            Console.WriteLine("Load initial BUS data ...");

            foreach (JToken result in busResults)
            {
                Bus busToAdd = result.ToObject<Bus>();
                unitOfWork.BusRepository.Add(busToAdd);
            }

            Console.WriteLine("Load initial USER data ...");

            foreach (JToken result in userResults)
            {
                User userToAdd = result.ToObject<User>();
                unitOfWork.UserRepository.Add(userToAdd);
            }

            //Problem with Bus_Id reading !!!
            //Console.WriteLine("Load initial SEAT data ...");

            //foreach (JToken result in seatResults)
            //{
            //    Seat seatToAdd = result.ToObject<Seat>();
            //    Console.WriteLine(seatToAdd.Bus.Id); 
            //    unitOfWork.SeatRepository.Add(seatToAdd);
            //}

            unitOfWork.Commit();
        }
    }
}
