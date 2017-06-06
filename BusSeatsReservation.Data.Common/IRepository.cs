namespace BusSeatsReservation.Data.Common
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetByID(int id);
    }
}
