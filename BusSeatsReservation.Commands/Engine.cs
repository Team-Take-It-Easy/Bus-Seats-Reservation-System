namespace BusSeatsReservation.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data.Common;
    using Utils;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandsFactory commandFactory;
        private EfUnitOfWork sqlUnitOfWork;
        private IValidator validator;
        private ICommandParser commandParser;

        public Engine(IReader reader, IWriter writer, ICommandsFactory commandFactory, EfUnitOfWork sqlUnitOfWork, IValidator validator, ICommandParser commandParser)
        {
            this.Writer = writer;
            this.Reader = reader;
            this.CommandsFactory = commandFactory;
            this.SQLUnitOfWork = sqlUnitOfWork;
            this.Validator = validator;
            this.CommandParser = commandParser;
        }

        internal IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                this.reader = value;
            }
        }

        internal IWriter Writer
        {
            get
            {
                return this.writer;
            }

            set
            {
                this.writer = value;
            }
        }

        internal ICommandsFactory CommandsFactory
        {
            get
            {
                return this.commandFactory;
            }

            set
            {
                this.commandFactory = value;
            }
        }

        internal EfUnitOfWork SQLUnitOfWork
        {
            get
            {
                return this.sqlUnitOfWork;
            }
            set
            {
                this.sqlUnitOfWork = value;
            }
        }

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

                List<string> parameters = input.Split(' ').ToList();

                command = this.CommandParser
                        .FindCommand(commandString, model, this.SQLUnitOfWork,
                                        this.Validator, this.Writer);

                this.Writer.Write(command.Execute(parameters));
            }
        }
    }
}
