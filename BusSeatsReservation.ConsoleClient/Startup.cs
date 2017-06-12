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

namespace BusSeatsReservation.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var sqlDbContext = new SQLDbContext();

            var repositoryFactory = new RepositoryFactory();
            var sqlUnitOfWork = new EfUnitOfWork(sqlDbContext, repositoryFactory);
            var validator = new Validator(writer, sqlUnitOfWork);
            var commandsFactory = new CommandsFactory(validator);
            var engine = new Engine(reader, writer, commandsFactory, sqlUnitOfWork, validator);

            engine.Start();
        }
    }
}

