using BusSeatsReservation.Commands.Contracts;
using BusSeatsReservation.Commands.Utils;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Models.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Commands.TripCommands
{
    public class CreateTripCommand : ICommand
    {
        public CreateTripCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
        {
            this.UnitOfWork = unitOfWork;
            this.Validator = validator;
            this.Writer = writer;
            this.Reader = reader;
        }

        public EfUnitOfWork UnitOfWork { get; protected set; }
        public IValidator Validator { get; protected set; }
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
            //this.Writer.Write($"{Constants.CreateTrip}");
        }
    }
}
