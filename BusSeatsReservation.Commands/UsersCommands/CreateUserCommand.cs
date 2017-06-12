namespace BusSeatsReservation.Commands.UsersCommands
{
    using Contracts;
    using Data.Common;
    using Models.SQL.Models;

    class CreateUserCommand
    {
        public CreateUserCommand(EfUnitOfWork unitOfWork, IValidator validator)
        {
            this.UnitOfWork = unitOfWork;
            this.Validator = Validator;
        }

        public EfUnitOfWork UnitOfWork { get; protected set; }
        public IValidator Validator { get; protected set; }

        public void Create(User user)
        {
            this.Validator.Validate(user);
            this.UnitOfWork.UserRepository.Add(user);
        }
    }
}
