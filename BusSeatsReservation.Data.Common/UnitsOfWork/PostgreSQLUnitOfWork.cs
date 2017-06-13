using System;
using BusSeatsReservation.Data.Common.Factories;
using System.Data.Entity;
using BusSeatsReservation.Models.PostgreSQL.Models;

namespace BusSeatsReservation.Data.Common.UnitsOfWork
{
    public class PostgreSQLUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        private IRepositoryFactory repositoryFactory;

        private SQLRepository<Creator> creatorsRepository;
        private SQLRepository<Report> reportsRepository;
        private SQLRepository<Log> logsRepository;

        public PostgreSQLUnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            this.context = context;
            this.repositoryFactory = repositoryFactory;
        }

        public SQLRepository<Creator> CreatorsRepository
        {
            get
            {
                if (this.creatorsRepository == null)
                {
                    this.creatorsRepository = repositoryFactory.CreateRepository<Creator>(context);
                }
                return this.creatorsRepository;
            }
        }

        public SQLRepository<Report> ReportsRepository
        {
            get
            {
                if (this.reportsRepository == null)
                {
                    this.reportsRepository = repositoryFactory.CreateRepository<Report>(context);
                }
                return this.reportsRepository;
            }
        }

        public SQLRepository<Log> LogsRepository
        {
            get
            {
                if (this.logsRepository == null)
                {
                    this.logsRepository = repositoryFactory.CreateRepository<Log>(context);
                }
                return this.logsRepository;
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
