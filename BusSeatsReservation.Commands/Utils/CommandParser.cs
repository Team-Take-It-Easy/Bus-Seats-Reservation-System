using BusSeatsReservation.Commands.Contracts;
using BusSeatsReservation.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Commands.Utils
{
    public class CommandParser : ICommandParser
    {
        public ICommand FindCommand(string commandName, string model, IUnitOfWork unitOfWork, IValidator validator, IWriter writer, IReader reader)
        {
            var fullCommand = string.Concat(commandName, model, "command");

            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(fullCommand.ToLower()))
                .SingleOrDefault();

            if(commandTypeInfo == null)
            {
                throw new ArgumentException($"{Constants.ErrorInvalidCommand}{Constants.AskForCommand}");
            }

            var command = Activator.CreateInstance(commandTypeInfo, unitOfWork, validator, writer, reader) as ICommand;
            return command;
        }
    }
}
