namespace BusSeatsReservation.Commands.UsersCommands
{
    using Data.Common;
    using Contracts;
    using Utils;

    class CreateUserCommand
    {
        public CreateUserCommand(IUnitOfWork unitOfWork, IWriter iLogger)
        {
            this.UnitOfWork = unitOfWork;
            this.ILogger = iLogger;
        }

        public IUnitOfWork UnitOfWork { get; protected set; }
        public IWriter ILogger { get; protected set; }
       
    }
}
