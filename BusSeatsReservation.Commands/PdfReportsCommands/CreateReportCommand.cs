using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Commands.Contracts;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Commands.Utils;
using BusSeatsReservation.Reports;

namespace BusSeatsReservation.Commands.PdfReportsCommands
{
    public class CreateReportCommand : ICommand
    {
        public CreateReportCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
        {
            this.UnitOfWork = unitOfWork;
            this.Validator = validator;
            this.Writer = writer;
            this.Reader = reader;
        }

        public EfUnitOfWork UnitOfWork { get; protected set; }
        public IValidator Validator { get; protected set; }
        public IWriter Writer { get; set; }
        public IReader Reader { get; set; }
 
        public void Execute()
        {
          
            this.Writer.Write($"{Constants.CreateReport}\n{Constants.AskForReportType}");
            string type = this.Reader.Read();
            if(type.ToLower() == "users")
            {
                
                var users = this.UnitOfWork.UserRepository.GetAll();
                PdfReport.GeneratePDFUsers(users);
                this.Writer.Write(Constants.ReportCreate);
                
            }
            
            else if(type.ToLower() == "trip")
            {
                this.Writer.Write($"{Constants.AskForTripId}\n");
                int tripId = int.Parse(this.Reader.Read());

                while(this.UnitOfWork.TripRepository.GetByID(tripId) == null)
                {
                    this.Writer.Write(Constants.SearchedTripDoesNotExist);
                    this.Writer.Write($"{Constants.AskForTripId}");
                    tripId = int.Parse(this.Reader.Read());
                }
                var trip = this.UnitOfWork.TripRepository.GetByID(tripId);
                PdfReport.GeneratePDFTrip(trip);
                this.Writer.Write(Constants.ReportCreate);
            }
            else
            {
                this.Writer.Write(Constants.InvalidReportType);
            }
        }
    }
}
