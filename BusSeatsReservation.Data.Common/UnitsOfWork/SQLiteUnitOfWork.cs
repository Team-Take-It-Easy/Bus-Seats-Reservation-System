using BusSeatsReservation.Data.Common.Factories;
using BusSeatsReservation.Models.SQLite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Data.Common.UnitsOfWork
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private IRepositoryFactory repositoryFactory;
        private SQLRepository<CurrentUserBus> busRepository;
        private SQLRepository<CurrentUserDestination> destinationRepository;
        private SQLRepository<CurrentUserReservation> reservationRepository;
        private SQLRepository<CurrentUserRoute> routeRepository;
        private SQLRepository<CurrentUserSeat> seatRepository;
        private SQLRepository<CurrentUserTrip> tripRepository;


        public SQLiteUnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            this.context = context;
            this.repositoryFactory = repositoryFactory;
        }

        public SQLRepository<CurrentUserBus> BusRepository
        {
            get
            {
                if (this.busRepository == null)
                {
                    this.busRepository = repositoryFactory.CreateRepository<CurrentUserBus>(context);
                }
                return this.busRepository;
            }
        }

        public SQLRepository<CurrentUserDestination> DestinationRepository
        {
            get
            {
                if (this.destinationRepository == null)
                {
                    this.destinationRepository = repositoryFactory.CreateRepository<CurrentUserDestination>(context);
                }
                return this.destinationRepository;
            }
        }

        public SQLRepository<CurrentUserTrip> TripRepository
        {
            get
            {
                if (this.tripRepository == null)
                {
                    this.tripRepository = this.repositoryFactory.CreateRepository<CurrentUserTrip>(context);
                }
                return this.tripRepository;
            }
        }

        public SQLRepository<CurrentUserReservation> ReservationRepository
        {
            get
            {
                if (this.reservationRepository == null)
                {
                    this.reservationRepository = this.repositoryFactory.CreateRepository<CurrentUserReservation>(context);
                }
                return this.reservationRepository;
            }
        }

        public SQLRepository<CurrentUserRoute> RouteRepository
        {
            get
            {
                if (this.routeRepository == null)
                {
                    this.routeRepository = this.repositoryFactory.CreateRepository<CurrentUserRoute>(context);
                }
                return this.routeRepository;
            }
        }

        public SQLRepository<CurrentUserSeat> SeatRepository
        {
            get
            {
                if (this.seatRepository == null)
                {
                    this.seatRepository = this.repositoryFactory.CreateRepository<CurrentUserSeat>(context);
                }
                return this.seatRepository;
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
