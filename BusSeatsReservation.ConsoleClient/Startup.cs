using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Data.Common.Factories;
using BusSeatsReservation.Data.Common.UnitsOfWork;
using BusSeatsReservation.Data.SQLite;
using BusSeatsReservation.Models.SQLite.Models;
namespace BusSeatsReservation.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var sqlLiteDbContext = new SQLiteDbContext();
            var repositoryFactory = new RepositoryFactory();
            var sqlLiteUnitOfWork = new SQLiteUnitOfWork(sqlLiteDbContext, repositoryFactory);

            sqlLiteUnitOfWork.DestinationRepository.Add(new CurrentUserDestination("Sofia"));

            sqlLiteUnitOfWork.Commit();
        }
    }
}
