namespace BusSeatsReservation.Commands.UsersCommands
{
    using System.Collections.Generic;

    using Contracts;
    using Data.Common;
    using Models.SQL.Models;
    using Utils;

    internal class CreateUserCommand : ICommand
    {
        public CreateUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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

        public User NewUser { get; set; }

        public void Execute()
        {
            this.Writer.Write($"{Constants.CreateUser}\n{Constants.AskForUserName}");
            var userName = this.Reader.Read();
            while(!this.Validator.Validate(userName, Constants.MinUserNameLength, Constants.MaxUserNameLength))
            {
                this.Writer.Write($"{Constants.ErrorUsernameWithInvalidLength}\n{Constants.AskForUserName}");
                userName = this.Reader.Read();
            }

            this.Writer.Write(Constants.AskForFirstName);
            var firstName = Reader.Read();

            this.Writer.Write(Constants.AskForLastName);
            var lastName = this.Reader.Read();
            while (!this.Validator.Validate(lastName, Constants.MinLastNameLength, Constants.MaxLastNameLength))
            {
                this.Writer.Write($"{Constants.ErrorLastNameWIthInvalidLength}\n{Constants.AskForLastName}");
                this.Writer.Write(Constants.AskForFirstName);
                lastName = this.Reader.Read();
            }

            this.NewUser = new User(userName, firstName, lastName);
            this.UnitOfWork.UserRepository.Add(NewUser);
            this.Writer.Write(Constants.UserCreated);
        }
    }
}
