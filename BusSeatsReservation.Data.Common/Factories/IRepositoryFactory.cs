using System.Collections.Generic;
using System.Data.Entity;

namespace BusSeatsReservation.Data.Common.Factories
{
    public interface IRepositoryFactory
    {
        SQLRepository<T> CreateRepository<T>(DbContext context) where T : class;
    }
}
