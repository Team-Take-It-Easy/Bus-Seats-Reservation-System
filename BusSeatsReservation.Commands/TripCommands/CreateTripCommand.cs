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
            this.Writer.Write($"{Constants.CreateTrip}");

            var allRoutes = this.UnitOfWork.RouteRepository.GetAll().ToList();

            foreach (var route in allRoutes)
            {
                var startHour = route.DepatureHour.ToString("HH:MM");
                this.Writer.Write($"Id: {route.Id} --- {route.FromDestination.Name} to {route.ToDestination.Name} --- {route.DayOfWeek} at {startHour}");
            }

            var idRouteString = this.Reader.Read();

            var selectedRoute = this.UnitOfWork.RouteRepository.GetByID(int.Parse(idRouteString));


            this.Writer.Write("Please, choose an ID of the listed buses:");

            var allBuses = this.UnitOfWork.BusRepository.GetAll().ToList();

            foreach (var bus in allBuses)
            {
                this.Writer.Write($"Id: {bus.Id} --- {bus.NumberOfSeats} seats --- {bus.Type}");
            }

            var idBusString = this.Reader.Read();
            var selectedBus = this.UnitOfWork.BusRepository.GetByID(int.Parse(idBusString));

            for (int i = 0; i < 3; i++)
            {
                DateTime nextTripDate = GetNextDate(DateTime.Today.AddDays(1+i*7), selectedRoute.DayOfWeek);

                var newTrip = new Trip()
                {
                    Route = selectedRoute,
                    Bus = selectedBus,
                    Date = nextTripDate
                };

                this.UnitOfWork.TripRepository.Add(newTrip);
            }

            this.UnitOfWork.Commit();
            this.Writer.Write(Constants.TripCreated);
        }

        private static DateTime GetNextDate(DateTime start, DayOfWeek day)
        {
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
    }
}
