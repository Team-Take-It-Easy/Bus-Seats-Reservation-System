

namespace BusSeatsReservation.Data.Common
{
    using System;
    using System.Data.Entity;

    using Factories;
    using Models.SQL.Models;

    public class EfUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        private IRepositoryFactory repositoryFactory;
        private SQLRepository<Bus> busRepository;
        private SQLRepository<Destination> destinationRepository;
        private SQLRepository<Reservation> reservationRepository;
        private SQLRepository<Route> routeRepository;
        private SQLRepository<Seat> seatRepository;
        private SQLRepository<User> userRepository;
        private SQLRepository<Trip> tripRepository;


        public EfUnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            this.context = context;
            this.repositoryFactory = repositoryFactory;
        }

        public SQLRepository<Bus> BusRepository
        {
            get
            {
                if (this.busRepository == null)
                {
                    this.busRepository = repositoryFactory.CreateRepository<Bus>(context);
                }
                return this.busRepository;
            }
        }

        public SQLRepository<Destination> DestinationRepository
        {
            get
            {
                if (this.destinationRepository == null)
                {
                    this.destinationRepository = repositoryFactory.CreateRepository<Destination>(context);
                }
                return this.destinationRepository;
            }
        }

        public SQLRepository<Trip> TripRepository
        {
            get
            {
                if (this.tripRepository == null)
                {
                    this.tripRepository = this.repositoryFactory.CreateRepository<Trip>(context);
                }
                return this.tripRepository;
            }
        }

        public SQLRepository<Reservation> ReservationRepository
        {
            get
            {
                if (this.reservationRepository == null)
                {
                    this.reservationRepository = this.repositoryFactory.CreateRepository<Reservation>(context);
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
                    this.routeRepository = this.repositoryFactory.CreateRepository<Route>(context);
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
                    this.seatRepository = this.repositoryFactory.CreateRepository<Seat>(context);
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
                    this.userRepository = repositoryFactory.CreateRepository<User>(context);
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
