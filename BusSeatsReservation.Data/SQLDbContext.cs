namespace BusSeatsReservation.Data
{
    using Models.SQL.Models;
    using System.Data.Entity;

    public class SQLDbContext : DbContext
    {
        public SQLDbContext()
            : base("BusSeatsReservationDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Hour> Hours { get; set; }

        public DbSet<Day> Days { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Seat> Seats { get; set; }
    }
}
