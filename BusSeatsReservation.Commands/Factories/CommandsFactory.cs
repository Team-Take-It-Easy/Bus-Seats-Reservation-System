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

        public ICommand CreateUserCommand(EfUnitOfWork unitOfWork, IValidator validator, IWriter writer)
        {
            return new CreateUserCommand(unitOfWork, validator, writer);
        }
    }
}
