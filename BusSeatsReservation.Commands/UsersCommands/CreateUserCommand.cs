namespace BusSeatsReservation.Commands.UsersCommands
{
    using Data.Common;
    using Models.SQL.Models;

    class CreateUserCommand
    {
        public CreateUserCommand(EfUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public EfUnitOfWork UnitOfWork { get; protected set; }
       
        public void Create(User user)
        {
            this.UnitOfWork.UserRepository.Add(user);
        }
    }
}
