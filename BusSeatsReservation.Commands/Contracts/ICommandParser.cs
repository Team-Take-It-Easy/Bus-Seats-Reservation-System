namespace BusSeatsReservation.Commands.Contracts
{
    using Data.Common;

    public interface ICommandParser
    {
        ICommand FindCommand(string commandName, string model, IUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader);
    }
}
