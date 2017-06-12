using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSeatsReservation.Commands.Contracts;
using BusSeatsReservation.Data.Common;
using BusSeatsReservation.Commands.UsersCommands;

namespace BusSeatsReservation.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private IValidator validator;

        public CommandsFactory(IValidator validator)
        {
            this.Validator = validator;
        }

        internal IValidator Validator
        {
            get
            {
                return this.validator;
            }

            set
            {
                this.validator = value;
            }
        }

        public ICommand CreateUserCommand(EfUnitOfWork unitOfWork)
        {
            return new CreateUserCommand(unitOfWork, this.Validator);
        }
    }
}
