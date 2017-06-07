using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusSeatsReservation.Models.PostgreSQL.Models;

namespace BusSeatsReservation.Data.Common.DataProviders
{
    public class PostgreSQLDataProvider: IDataProvider
    {
        private IUnitOfWork unitOfWork;
        private IRepository<BusType> busesRepository;

        public PostgreSQLDataProvider(IUnitOfWork unitOfWork, IRepository<BusType> busesRepository)
        {
            this.UnitOfWork = unitOfWork;
            this.BusesRepository = busesRepository;
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

        public IRepository<BusType> BusesRepository
        {
            get
            {
                return this.busesRepository;
            }

            set
            {
                this.busesRepository = value;
            }
        }
    }
}
