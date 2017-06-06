using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Models.SQL.Models;

namespace BusSeatsReservation.Data.Common.DataProviders
{
    public class SQLDataProvider : IDataProvider
    {
        private IUnitOfWork unitOfWork;
        private IRepository<User> usersRepository;
        private IRepository<Reservation> reservationsRepository;

        public SQLDataProvider(IUnitOfWork unitOfWork, IRepository<User> usersRepository, IRepository<Reservation> reservationsRepository)
        {
            this.UnitOfWork = unitOfWork;
            this.UsersRepository = usersRepository;
            this.ReservationsRepository = reservationsRepository;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }

            set
            {
                this.unitOfWork = value;
            }
        }

        public IRepository<User> UsersRepository
        {
            get
            {
                return this.usersRepository;
            }
            
            set
            {
                this.usersRepository = value;
            }
        }

        public IRepository<Reservation> ReservationsRepository
        {
            get
            {
                return this.reservationsRepository;
            }

            set
            {
                this.reservationsRepository = value;
            }
        }
    }
}
