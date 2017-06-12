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

        public DbSet<CurrentUserBus> CurrentUserBuses { get; set; }

        public DbSet<CurrentUserDestination> CurrentUserDestinations { get; set; }

        public DbSet<CurrentUserReservation> ReservationsCurrentUserReservations { get; set; }

        public DbSet<CurrentUserRoute> CurrentUserRoutes { get; set; }

        public DbSet<CurrentUserSeat> CurrentUserSeats { get; set; }

        public DbSet<CurrentUserTrip> CurrentUserTrips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SQLiteDbContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

    }
}
