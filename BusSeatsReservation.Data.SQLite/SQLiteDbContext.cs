using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using BusSeatsReservation.Models.SQLite.Models;
using SQLite.CodeFirst;

namespace BusSeatsReservation.Data.SQLite
{
    public class SQLiteDbContext: DbContext
    {
        public SQLiteDbContext()
            : base("BusSeatsReservationSQLiteDb")
        {
        }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SQLiteDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

    }
}
