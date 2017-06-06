namespace BusSeatsReservation.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class SQLRepository<T> : IRepository<T> where T:class
    {
        private SQLDbContext context;
        private DbSet sqlDbSet;

        public SQLRepository(SQLDbContext context)
        {
            this.Context = context;
            this.SqlDbSet = this.Context.Set<T>();
        }

        public SQLDbContext Context { get; protected set; }
        public DbSet<T> SqlDbSet { get; protected set; }

        public void Add(T entity)
        {
            this.SqlDbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.SqlDbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return this.SqlDbSet;
        }

        public T GetByID(int id)
        {
            return this.SqlDbSet.Find(id);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.SqlDbSet.Where(predicate);
        }
    }
}
