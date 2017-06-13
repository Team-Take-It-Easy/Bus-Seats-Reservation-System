using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Data.Common.Factories;
using BusSeatsReservation.Data.Common.UnitsOfWork;
using BusSeatsReservation.Data.SQLite;
using BusSeatsReservation.Models.SQLite.Models;

using BusSeatsReservation.Commands;
using BusSeatsReservation.Commands.Readers;
using BusSeatsReservation.Commands.Writers;
using BusSeatsReservation.Commands.Factories;
using BusSeatsReservation.Data;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Commands.Utils;
using BusSeatsReservation.Data.PostgreSQL;

namespace BusSeatsReservation.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var sqlDbContext = new SQLDbContext();
            var sqliteDbContext = new SQLiteDbContext();
            var postgreSQLContext = new PostgreSQLDbContext();

            var repositoryFactory = new RepositoryFactory();

            var sqlUnitOfWork = new EfUnitOfWork(sqlDbContext, repositoryFactory);
            var sqliteUnitOfWork = new SQLiteUnitOfWork(sqliteDbContext, repositoryFactory);
            var postgreUnitOfWork = new PostgreSQLUnitOfWork(postgreSQLContext, repositoryFactory);

            var validator = new Validator(writer, sqlUnitOfWork);
            var commandsFactory = new CommandsFactory();
            var commandParser = new CommandParser();
            var cacheLoader = new CacheLoader();

            var engine = new Engine(reader, writer, commandsFactory, sqlUnitOfWork, sqliteUnitOfWork, postgreUnitOfWork, validator, commandParser, cacheLoader);

            //DataParser.LoadInitialData(sqlUnitOfWork);

            engine.Start();
        }
    }
}

