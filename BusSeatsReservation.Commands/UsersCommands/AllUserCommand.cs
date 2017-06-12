namespace BusSeatsReservation.Commands.UsersCommands
{
    using System.Text;

    using Data.Common;
    using Contracts;
    using Utils;

    public class AllUserCommand : ICommand
    {
        public AllUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
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
            var allUsers = this.UnitOfWork.UserRepository.GetAll();

            StringBuilder sb = new StringBuilder();
            sb.Append(Constants.AllUsers);

            foreach (var user in allUsers)
            {
                sb.Append($"Username: {user.UserName} ---");
                sb.Append($"First name: {user.FirstName} ---");
                sb.Append($"Last name: {user.LastName} ---");
                sb.Append("\n");
            }

            this.Writer.Write(sb.ToString());
        }
    }
}
