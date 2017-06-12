namespace BusSeatsReservation.Commands.Contracts
{
    using Data.Common;

    public interface ICommandsFactory
    {
        ICommand CreateUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader);
    }
}
