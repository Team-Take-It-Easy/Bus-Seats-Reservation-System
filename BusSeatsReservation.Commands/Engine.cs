namespace BusSeatsReservation.Commands
{
    using Contracts;
    using Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandsFactory commandFactory;
        private EfUnitOfWork sqlUnitOfWork;

        public Engine(IReader reader, IWriter writer, ICommandsFactory commandFactory, EfUnitOfWork sqlUnitOfWork)
        {
            this.Writer = writer;
            this.Reader = reader;
            this.CommandsFactory = commandFactory;
            this.SQLUnitOfWork = sqlUnitOfWork;
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

                command = this.CreateCommand(commandString, model, this.sqlUnitOfWork);

                this.Writer.Write(command.Execute(parameters));
            }



        }

        private ICommand CreateCommand(string command, string model, EfUnitOfWork unitOfWork)
        {
            if (command.ToLower() == "create")
            {
                switch (model.ToLower())
                {
                    case "user":
                        return this.commandFactory.CreateUserCommand(unitOfWork);
                    default:
                        throw new Exception("The passed command is not valid!");
                }
            }
            else
            {
                throw new Exception("The passed command is not valid!");
            }
        }
    }
}
