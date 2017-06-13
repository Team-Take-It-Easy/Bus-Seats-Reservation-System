namespace BusSeatsReservation.Commands.ReservationsCommands
{
    using System;
    using Contracts;
    using Data.Common;
    using Utils;
    using System.Linq;
    using Models.SQL.Models;

    public class CreateReservationCommand : ICommand
    {
        public CreateReservationCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            this.Writer.Write(Constants.CreateReservation);
            this.Writer.Write(Constants.AskForUserByUsername);

            var userName = this.Reader.Read();

            try
            {
                var user = this.UnitOfWork.UserRepository.Search(u => u.UserName == userName).First();
            }
            catch
            {
                //this.Writer.Write($"{Constants.SearchedUserDoesNotExist}\n{Constants.AskToCreateUser}\n{Constants.AskForCommandShort}");
                this.Writer.Write($"{Constants.SearchedUserDoesNotExist}\n{Constants.AskForCommandShort}");
                return;
            }

            this.Writer.Write($"{Constants.FoundUser}");

            // trip
            this.Writer.Write("Please write START destination you are looking for:");
            var startDestination = this.Reader.Read();

            this.Writer.Write("Please write END destination you are looking for:");
            var endDestination = this.Reader.Read();

            var allTrips = this.UnitOfWork.TripRepository.Search(tr => tr.Route.FromDestination.Name.ToLower() == startDestination.ToLower() &&
                                                                       tr.Route.ToDestination.Name.ToLower() == endDestination.ToLower()).ToList();
            foreach (var trip in allTrips)
            {
                var startHour = trip.Route.DepatureHour.ToString("HH:MM");
                var tripDate = trip.Date.ToShortDateString();
                var notOcuppiedSeats = trip.Bus.NumberOfSeats - trip.Reservations.Count();
                this.Writer.Write($"Id: {trip.Id} --- {trip.Route.FromDestination.Name} to {trip.Route.ToDestination.Name} --- {tripDate} at {startHour}");
                this.Writer.Write($"Number of not ocuppied seats : {notOcuppiedSeats}\n");
            }

            this.Writer.Write("Please write the ID of the trip:");
            var selectedTrip = int.Parse(this.Reader.Read());

            var reservedSeats = this.UnitOfWork.TripRepository
                .GetByID(selectedTrip)
                .Reservations
                .Select(r => r.Seat.Label)
                .ToList();

            var otherSeats = this.UnitOfWork.TripRepository
                .GetByID(selectedTrip)
                .Bus
                .Seats
                .Select(m => m.Label)
                .ToList();

            var seatDifference =
                from seat2 in otherSeats
                where !(
                from seat1 in reservedSeats
                select seat1
                ).Contains(seat2)
                select seat2;

            foreach (var item in seatDifference)
            {
                this.Writer.Write($"{item}");
            }

            // seat

            this.Writer.Write($"Please, choose a seat from the list:\n");
            var selectedSeat = this.Reader.Read();


            var thisTrip = this.UnitOfWork.TripRepository.GetByID(selectedTrip);
            var thisUser = this.UnitOfWork.UserRepository.Search(u => u.UserName == userName).First();

            // Does not work 
            var thisSeat = this.UnitOfWork.SeatRepository
                .Search(s => s.Label == selectedSeat)
                .Where(b => b.Bus.Id == thisTrip.Bus.Id)
                .First();


            var newReservation = new Reservation()
            {
                User = thisUser,
                Trip = thisTrip,
                Seat = thisSeat
            };

            this.UnitOfWork.ReservationRepository.Add(newReservation);
            this.UnitOfWork.Commit();
            this.Writer.Write(Constants.ReservationCreated);
        }
    }
}
