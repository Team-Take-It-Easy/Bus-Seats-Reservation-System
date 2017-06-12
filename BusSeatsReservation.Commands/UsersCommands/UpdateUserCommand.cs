namespace BusSeatsReservation.Commands.UsersCommands
{
    using System.Linq;

    using Contracts;
    using Data.Common;
    using Utils;

    class UpdateUserCommand : ICommand
    {
        public UpdateUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            this.Writer.Write(Constants.AskForUserByUsername);
            var userName = this.Reader.Read();

            var userToEdit = this.UnitOfWork.UserRepository.Search(user => user.UserName == userName).First();

            if(userName == null)
            {
                this.Writer.Write($"{Constants.SearchedUserDoesNotExist}\n{Constants.AskForCommandShort}");
            }
            
            else
            {
                this.Writer.Write(Constants.AskForFirstName);
                var firstName = this.Reader.Read();

                this.Writer.Write(Constants.AskForLastName);
                var lastName = this.Reader.Read();

                while (!this.Validator.Validate(lastName, Constants.MinLastNameLength, Constants.MaxLastNameLength))
                {
                    this.Writer.Write($"{Constants.ErrorLastNameWIthInvalidLength}\n{Constants.AskForLastName}");
                    this.Writer.Write(Constants.AskForFirstName);
                    lastName = this.Reader.Read();
                }

                userToEdit.FirstName = firstName;
                userToEdit.LastName = lastName;
                this.UnitOfWork.Commit();

                this.Writer.Write($"User {userName} edited!");
            }
        }
    }
}
