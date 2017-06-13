namespace BusSeatsReservation.Commands.ReservationsCommands
{
    using System;
    using Contracts;
    using Data.Common;
    using Utils;
    using System.Linq;

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


            // seat

        }
    }
}
