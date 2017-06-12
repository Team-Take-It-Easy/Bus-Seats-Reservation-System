namespace BusSeatsReservation.Commands.Utils
{
    using System;

    using Contracts;
    using Models.SQL.Models;
    using Models.Enums;
    using Data.Common;
    using System.Linq;
    using System.Linq.Expressions;

    internal class Validator : IValidator
    {
        public Validator(IWriter writer, EfUnitOfWork unitOfWork)
        {
            this.Writer = writer;
            this.UnitOfWork = unitOfWork;
        }

        private IWriter Writer { get; set; }
        private EfUnitOfWork UnitOfWork { get; set; }

        public bool Validate(Bus bus)
        {
            if (!Enum.IsDefined(typeof(BusType), bus.Type))
            {
                this.Writer.Write(Constants.ErrorBusTypeIsNotValid);
                return false;
            }

            if (bus.NumberOfSeats < Constants.MinBusSeatsCount || bus.NumberOfSeats > Constants.MaxBusSeatsCount)
            {
                this.Writer.Write(Constants.ErrorInvalidNumberOfSeats);
                return false;
            }

            return true;
        }

        public bool Validate(Destination destination)
        {
            if(string.IsNullOrEmpty(destination.Name))
            {
                // message
                return false;
            }

            var repository = this.UnitOfWork.DestinationRepository;
            if (FindElementInDatabase<Destination>(repository, (x => x.Name == destination.Name)))
            {
                this.Writer.Write(Constants.ErrorDestinationNameMustBeUnique);
                return false;
            }
            return true;
        }

        public bool Validate(Reservation reservation)
        {
            if (reservation.Trip == null)
            {
                this.Writer.Write(Constants.ErrorCreatingReservationWithNullTrip);
                return false;
            }

            return true;
        }

        public bool Validate(Route route)
        {
            if (route.FromDestination == null)
            {
                this.Writer.Write(Constants.ErrorEmptyFromDestination);
                return false;
            }
            if (route.ToDestination == null)
            {
                this.Writer.Write(Constants.ErrorEmptyToDestination);
                return false;
            }

            return true;
        }

        public bool Validate(Seat seat)
        {
            if (string.IsNullOrEmpty(seat.Label))
            {
                this.Writer.Write(Constants.ErrorNoSeatLabel);
                return false;
            }

            if (seat.Bus == null)
            {
                this.Writer.Write(Constants.ErrorNoSeatBus);
                return false;
            }

            return true;
        }

        public bool Validate(Trip trip)
        {
            if (trip.Bus == null)
            {
                this.Writer.Write(Constants.ErrorNoTripBus);
                return false;
            }

            if (trip.Route == null)
            {
                this.Writer.Write(Constants.ErrorNoTripRoute);
                return false;
            }

            if (trip.Date == null)
            {
                this.Writer.Write(Constants.ErrorNoTripDate);
                return false;
            }

            return true;
        }

        public bool Validate(User user)
        {

            var repository = this.UnitOfWork.UserRepository;
            if (FindElementInDatabase<User>(repository, u => u.UserName == user.UserName))
            {
                this.Writer.Write(Constants.ErrorUserAlreadyExists);
                return false;
            }

            if (string.IsNullOrEmpty(user.UserName))
            {
                this.Writer.Write(Constants.ErrorNoUsername);
                return false;
            }

            if (user.UserName.Length < Constants.MinUserNameLength || user.UserName.Length > Constants.MaxBusSeatsCount)
            {
                this.Writer.Write(Constants.ErrorUsernameWithInvalidLength);
                return false;
            }

            if(string.IsNullOrEmpty(user.LastName))
            {
                this.Writer.Write(Constants.ErrorNoLastName);
                return false;
            }

            if(user.LastName.Length < Constants.MinLastNameLength || user.LastName.Length > Constants.MaxLastNameLength)
            {
                this.Writer.Write(Constants.ErrorLastNameWIthInvalidLength);
                return false;
            }

            return true;
        }

        public bool Validate(string value, int minLength, int maxLength, string message = "")
        {
            if(string.IsNullOrEmpty(value))
            {
                this.Writer.Write(Constants.ErrorStringCannotBeNull);
                return false;
            }
            if(value.Length < minLength || value.Length > maxLength)
            {
                this.Writer.Write(message);
                return false;
            }

            return true;
        }

        public bool Validate(int value, int min, int max, string message)
        {
            if(value < min || value > max)
            {
                this.Writer.Write(message);
                return false;
            }

            return true;
        }

        private bool FindElementInDatabase<T>(IRepository<T> repository, Expression<Func<T, bool>> predicate)
        {
            var result = repository.Search(predicate);

            if (result != null && result.Any())
            {
                return true;
            }

            return false;
        }
    }
}
