using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Models.SQL.Models;

namespace BusSeatsReservation.Commands.Contracts
{
    public interface IValidator
    {
        bool Validate(Bus bus);
        bool Validate(Destination destination);
        bool Validate(Reservation reservation);
        bool Validate(Route route);
        bool Validate(Seat seat);
        bool Validate(Trip trip);
        bool Validate(User user);
    }
}
