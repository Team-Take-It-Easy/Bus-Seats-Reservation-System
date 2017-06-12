namespace BusSeatsReservation.Commands.ReservationsCommands
{
    using System.Linq;
    using System.Text;

    using Contracts;
    using Data.Common;
    using Utils;
    using System;

    class AllReservationCommand : ICommand
    {
        public AllReservationCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            var allReservations = this.UnitOfWork.ReservationRepository.GetAll().
                                                OrderBy(reservation => reservation.User.UserName,
                                                        StringComparer.CurrentCultureIgnoreCase)
                                                .ThenBy(reservation => reservation.Trip.Date);

            StringBuilder sb = new StringBuilder();
            sb.Append(Constants.AllReservations);

            foreach (var reservation in allReservations)
            {
                sb.Append($"User: {reservation.User.UserName} --- trip: {reservation.Trip.Date} --- Seat: {reservation.Seat.Label}\n");
            }

            this.Writer.Write(sb.ToString());
        }
    }
}
