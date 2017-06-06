using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using BusSeatsReservation.Models.PostgreSQL.Models;

namespace BusSeatsReservation.Data.PostgreSQL
{
    public class PostgreSQLDbContext: DbContext
    {

        public PostgreSQLDbContext()
            : base("BusSeatsReservationPostgreSQLDb")
        {
        }

        public DbSet<Bus> Buses{ get; set; }
    }
}
