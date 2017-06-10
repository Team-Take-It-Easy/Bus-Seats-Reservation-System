namespace BusSeatsReservation.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetByID(int id);
    }
}
