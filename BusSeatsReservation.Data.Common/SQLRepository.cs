namespace BusSeatsReservation.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class SQLRepository<T> : IRepository<T> where T:class
    {
        public SQLRepository(DbContext context)
        {
            this.Context = context;
            this.SqlDbSet = this.Context.Set<T>();
        }

        private DbContext Context { get; set; }
        private DbSet<T> SqlDbSet { get; set; }

        public void Add(T entity)
        {
            this.SqlDbSet.Add(entity);
        }

        public void Update(T entity)
        {
            var entry = this.Context.Entry(entity);

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this.SqlDbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.SqlDbSet;
        }

        public T GetByID(int id)
        {
            return this.SqlDbSet.Find(id);
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.SqlDbSet.Where(predicate);
        }
    }
}
