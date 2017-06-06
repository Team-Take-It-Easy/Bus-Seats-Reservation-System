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
    }
}
