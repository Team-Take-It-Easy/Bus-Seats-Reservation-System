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
    class CommandParser
    {
        public CommandParser()
        {

        }

        public ICommand FindCommand(string commandName, string model, IUnitOfWork unitOfWork, IValidator validator)
        {
            var fullCommand = string.Concat(commandName, model, "command");
            Console.WriteLine(fullCommand);
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(fullCommand.ToLower()))
                .SingleOrDefault();

            if(commandTypeInfo == null)
            {
                throw new ArgumentException("wrong command");
            }

            var command = Activator.CreateInstance(commandTypeInfo, unitOfWork, validator) as ICommand;
            return command;
        }
    }
}
