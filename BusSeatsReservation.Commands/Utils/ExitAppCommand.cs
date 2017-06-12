namespace BusSeatsReservation.Commands.Utils
{
    using Contracts;
    using Data.Common;
    using System;

    public class ExitAppCommand : ICommand
    {
        public ExitAppCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            this.Writer.Write(Constants.ExitMessage);
            Environment.Exit(0);
        }
    }
}
