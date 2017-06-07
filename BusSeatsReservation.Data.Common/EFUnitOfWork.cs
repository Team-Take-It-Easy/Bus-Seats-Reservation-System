

namespace BusSeatsReservation.Data.Common
{
    using System;
    using System.Data.Entity;

    using Models.SQL.Models;

    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        private SQLRepository<Bus> busRepository;
        private SQLRepository<Day> dayRepository;
        private SQLRepository<Destination> destinationRepository;
        private SQLRepository<Hour> hourRepository;
        private SQLRepository<Reservation> reservationRepository;
        private SQLRepository<Route> routeRepository;
        private SQLRepository<Seat> seatRepository;
        private SQLRepository<User> userRepository;

        public EfUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public SQLRepository<Bus> BusRepository
        {
            get
            {
                if (this.busRepository == null)
                {
                    this.busRepository = new SQLRepository<Bus>(context);
                }
                return this.busRepository;
            }
        }

        public SQLRepository<Day> DayRepository
        {
            get
            {
                if (this.dayRepository == null)
                {
                    this.dayRepository = new SQLRepository<Day>(context);
                }
                return this.dayRepository;
            }
        }

        public SQLRepository<Destination> DestinationRepository
        {
            get
            {
                if (this.destinationRepository == null)
                {
                    this.destinationRepository = new SQLRepository<Destination>(context);
                }
                return this.destinationRepository;
            }
        }

        public SQLRepository<Hour> HourRepository
        {
            get
            {
                if (this.hourRepository == null)
                {
                    this.hourRepository = new SQLRepository<Hour>(context);
                }
                return this.hourRepository;
            }
        }

        public SQLRepository<Reservation> ReservationRepository
        {
            get
            {
                if (this.reservationRepository == null)
                {
                    this.reservationRepository = new SQLRepository<Reservation>(context);
                }
                return this.reservationRepository;
            }
        }

        public SQLRepository<Route> RouteRepository
        {
            get
            {
                if (this.routeRepository == null)
                {
                    this.routeRepository = new SQLRepository<Route>(context);
                }
                return this.routeRepository;
            }
        }

        public SQLRepository<Seat> SeatRepository
        {
            get
            {
                if (this.seatRepository == null)
                {
                    this.seatRepository = new SQLRepository<Seat>(context);
                }
                return this.seatRepository;
            }
        }

        public SQLRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new SQLRepository<User>(context);
                }
                return this.userRepository;
            }
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
