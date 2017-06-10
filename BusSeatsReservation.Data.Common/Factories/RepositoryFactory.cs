using System.Collections.Generic;
using System.Data.Entity;


namespace BusSeatsReservation.Data.Common.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public SQLRepository<T> CreateRepository<T>(DbContext context) where T: class
        {
            return new SQLRepository<T>(context);
        }
    }
}
