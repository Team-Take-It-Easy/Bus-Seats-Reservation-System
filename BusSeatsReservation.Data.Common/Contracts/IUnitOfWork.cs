using System;

namespace BusSeatsReservation.Data.Common
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
    }
}
