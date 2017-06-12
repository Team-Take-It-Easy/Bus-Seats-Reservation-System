namespace BusSeatsReservation.Commands.Contracts
{
    interface IValidator
    {
        bool ValidateString();
        bool ValidateInteger();
    }
}
