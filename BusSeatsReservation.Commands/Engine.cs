namespace BusSeatsReservation.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data.Common;
    using Utils;

    public class Engine
    {
        public Engine(IReader reader, IWriter writer, ICommandsFactory commandFactory, EfUnitOfWork sqlUnitOfWork, IValidator validator, ICommandParser commandParser)
        {
            this.Writer = writer;
            this.Reader = reader;
            this.CommandsFactory = commandFactory;
            this.SQLUnitOfWork = sqlUnitOfWork;
            this.Validator = validator;
            this.CommandParser = commandParser;
        }

        internal IReader Reader { get; set; }

        internal IWriter Writer { get; set; }

        internal ICommandsFactory CommandsFactory { get; set; }

        internal EfUnitOfWork SQLUnitOfWork { get; set; }

        public IValidator Validator { get; set; }

        public ICommandParser CommandParser { get; set; }

        public void Start()
        {
            this.Writer.Write(Constants.AskForCommand);
            string commandString = "";
            string model = "";
            ICommand command;

            while (true)
            {
                string input = this.Reader.Read();

                foreach (var c in Constants.CommandsList)
                {
                    if (input.ToLower().Contains(c.ToLower()))
                    {
                        commandString = c;
                    }
                }

                foreach (var m in Constants.ModelsList)
                {
                    if (input.ToLower().Contains(m.ToLower()))
                    {
                        model = m;
                    }
                }
                
                command = this.CommandParser
                        .FindCommand(commandString, model, this.SQLUnitOfWork,
                                        this.Validator, this.Writer, this.Reader);

                command.Execute();
            }
        }
    }
}
