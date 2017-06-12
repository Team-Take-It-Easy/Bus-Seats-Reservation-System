namespace BusSeatsReservation.Commands.UsersCommands
{
    using System.Collections.Generic;

    using Contracts;
    using Data.Common;
    using Models.SQL.Models;
    using Utils;

    internal class CreateUserCommand : ICommand
    {
        public CreateUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer)
        {
            this.UnitOfWork = unitOfWork;
            this.Validator = Validator;
        }

        public EfUnitOfWork UnitOfWork { get; protected set; }
        public IValidator Validator { get; protected set; }

        public void Execute(IList<string> parameters)
        {
            var a = $"{Constants.CreateUser}\n{Constants.AskForUserName}";
            
        }

        public void Create(User user)
        {
            this.Validator.Validate(user);
            this.UnitOfWork.UserRepository.Add(user);
        }

        string ICommand.Execute(IList<string> parameters)
        {
            return "Done";
        }
    }
}
