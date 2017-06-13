using BusSeatsReservation.Commands.Contracts;
using BusSeatsReservation.Commands.Utils;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Models.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Commands.RoutesCommands
{
    public class CreateRouteCommand : ICommand
    {
        public CreateRouteCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            this.Writer.Write($"{Constants.CreateRoute}\n{Constants.AskForStartPoint}");

            var startCityString = this.Reader.Read();

            while (!this.Validator.Validate(startCityString, 2, 200))
            {
                this.Writer.Write($"{Constants.AskForStartPoint}");
                startCityString = this.Reader.Read();
            }

            this.Writer.Write(Constants.AskForDestinaion);
            var destinationString = Reader.Read();

            while (!this.Validator.Validate(destinationString, 2, 200) || startCityString.ToLower() == destinationString.ToLower())
            {
                this.Writer.Write($"{Constants.AskForDestinaion}");
                destinationString = this.Reader.Read();
            }

            this.Writer.Write(Constants.AskForWeekDay);
            var dayOfWeekString = this.Reader.Read();

            while (!(int.Parse(dayOfWeekString) >= 1 && int.Parse(dayOfWeekString) <=7))
            {
                this.Writer.Write($"{Constants.AskForWeekDay}");
                dayOfWeekString = this.Reader.Read();
            }

            this.Writer.Write(Constants.AskForHour);
            var hourString = this.Reader.Read().Split(':');

            while (!(int.Parse(hourString[0]) >= 0 && int.Parse(hourString[0]) <= 23 && int.Parse(hourString[1]) >= 0 && int.Parse(hourString[1]) <= 59))
            {
                this.Writer.Write($"{Constants.ErrorNotValidHour}\n{Constants.AskForWeekDay}");
                hourString = this.Reader.Read().Split(':');
            }

            var newRoute = new Route()
            {
                FromDestination = LoadOrCreateDestination(startCityString, this.UnitOfWork),
                ToDestination = LoadOrCreateDestination(destinationString, this.UnitOfWork),
                DayOfWeek = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), int.Parse(dayOfWeekString)),
                DepatureHour = DateTime.Today.Add(new TimeSpan(int.Parse(hourString[0]), int.Parse(hourString[1]), 00)),
            };

            this.UnitOfWork.RouteRepository.Add(newRoute);
            this.UnitOfWork.Commit();
            this.Writer.Write(Constants.RouteCreated);
        }

        private static Destination LoadOrCreateDestination(string city, EfUnitOfWork unitOfWork)
        {
            var destination = unitOfWork.DestinationRepository.Search(d => d.Name.ToLower() == city.ToLower()).FirstOrDefault();

            if (destination == null)
            {
                destination = new Destination()
                {
                    Name = city
                };
            }

            return destination;
        }
    }
}
