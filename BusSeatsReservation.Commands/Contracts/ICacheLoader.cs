using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Data.Common.UnitsOfWork;

namespace BusSeatsReservation.Commands.Contracts
{
    public interface ICacheLoader
    {
        void LoadData(int userId, EfUnitOfWork efUnitOfWork, SQLiteUnitOfWork sqliteUnitOfWork);
    }
}
