namespace BusSeatsReservation.Commands.UsersCommands
{
    using System.Linq;

    using Contracts;
    using Data.Common;
    using Utils;
    using Models.SQL.Models;

    class DeleteUserCommand : ICommand
    {
        public DeleteUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            this.Writer.Write($"{ Constants.DeleteUser}\n{Constants.AskForUserByUsername}");
            var userName = this.Reader.Read();

            while (!this.Validator.Validate(userName, Constants.MinUserNameLength, Constants.MaxUserNameLength))
            {
                this.Writer.Write($"{Constants.ErrorUsernameWithInvalidLength}\n{Constants.AskForUserByUsername}");
                userName = this.Reader.Read();
            }
            User userToDelete = null;
            try
            {
                userToDelete = this.UnitOfWork.UserRepository.Search(user => user.UserName == userName).First();
            }
            catch
            {
                this.Writer.Write($"{Constants.SearchedUserDoesNotExist}\n{Constants.AskForCommandShort}");
                return;
            }

            this.UnitOfWork.UserRepository.Delete(userToDelete);
            this.Writer.Write($"User {userName} {Constants.EntityDeletedSuccessfully}!");
            this.UnitOfWork.Commit();
        }
    }
}
