namespace BusSeatsReservation.Data
{
    using Models.SQL.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SQLDbContext : DbContext
    {
        public SQLDbContext()
            : base("BusSeatsReservationDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Bus> Buses { get; set; }

        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Route>()
                .HasMany<Bus>(s => s.Buses)
                .WithMany(c => c.Routes)
                .Map(cs =>
                {
                    cs.MapLeftKey("RouteId");
                    cs.MapRightKey("BusId");
                    cs.ToTable("RouteBuses");
                });

            modelBuilder
                .Entity<Bus>()
                .Property(t => t.RegNumber)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName,
                     new IndexAnnotation(
                        new IndexAttribute("IX_RegNumber", 1) { IsUnique = true }));
        }
    }
}
