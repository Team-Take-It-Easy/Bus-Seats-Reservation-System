using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using BusSeatsReservation.Models.PostgreSQL.Models;

namespace BusSeatsReservation.Data.PostgreSQL
{
    public class PostgreSQLDbContext : DbContext
    {

        public PostgreSQLDbContext()
            : base("BusSeatsReservationPostgreSQLDb")
        {
        }

        public DbSet<Creator> Creators { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<Log> Logs { get; set; }
    }
}