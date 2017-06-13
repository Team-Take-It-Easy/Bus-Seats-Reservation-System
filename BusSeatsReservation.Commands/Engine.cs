namespace BusSeatsReservation.Commands
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data.Common;
    using Utils;
    using Data.Common.UnitsOfWork;
    using System;
    using Models.PostgreSQL.Models;

    public class Engine
    {
        public Engine(IReader reader, IWriter writer, ICommandsFactory commandFactory, EfUnitOfWork sqlUnitOfWork, SQLiteUnitOfWork sqliteUnitOfWork, PostgreSQLUnitOfWork postgreSQLUnitOfWork, IValidator validator, ICommandParser commandParser, ICacheLoader cacheLoader)
        {
            this.Writer = writer;
            this.Reader = reader;
            this.CommandsFactory = commandFactory;
            this.SQLUnitOfWork = sqlUnitOfWork;
            this.SQLiteUnitOfWork = sqliteUnitOfWork;
            this.PostgreSQLUnitOfWork = postgreSQLUnitOfWork;            
            this.Validator = validator;
            this.CommandParser = commandParser;
            this.CacheLoader = cacheLoader;
        }

        internal IReader Reader { get; set; }

        internal IWriter Writer { get; set; }

        internal ICommandsFactory CommandsFactory { get; set; }

        internal EfUnitOfWork SQLUnitOfWork { get; set; }

        internal SQLiteUnitOfWork SQLiteUnitOfWork { get; set; }

        internal PostgreSQLUnitOfWork PostgreSQLUnitOfWork { get; set; }

        public IValidator Validator { get; set; }

        public ICommandParser CommandParser { get; set; }

        public ICacheLoader CacheLoader { get; set; }

        public void Start()
        {
            this.Writer.Write(Constants.AskForCommandLong);
            string commandString = "";
            string model = "";
            ICommand command;
            int currentUserId = -1;

            this.Writer.Write("Welcome! Please enter your username or create new user");
            string currentUserUsername = this.Reader.Read();
            currentUserId = this.GetCurrentUserId(currentUserUsername);

            while (currentUserId < 0)
            {
                command = this.CommandParser
                    .FindCommand("create", "user", this.SQLUnitOfWork,
                           this.Validator, this.Writer, this.Reader);

                try
                {
                    command.Execute();
                    currentUserUsername = this.Reader.Read();
                    currentUserId = this.GetCurrentUserId(currentUserUsername);
                }

                catch (Exception ex)
                {
                    this.Writer.Write("Unsuccessful command execution, please try again");
                    this.Writer.Write(ex.Message);
                    continue;
                }
            }

            this.CacheLoader.LoadData(currentUserId, this.SQLUnitOfWork, this.SQLiteUnitOfWork);
            this.AddUserLog(currentUserId);

            this.Writer.Write(Constants.SuccessfulSignedIn);
            while (true)
            {
                string input = this.Reader.Read();

                foreach (var c in Constants.CommandsList)
                {
                    if (input.ToLower().Contains(c.ToLower()))
                    {
                        commandString = c;
                        break;
                    }
                }

                foreach (var m in Constants.ModelsList)
                {
                    if (input.ToLower().Contains(m.ToLower()))
                    {
                        model = m;
                        break;
                    }
                }
                
                command = this.CommandParser
                        .FindCommand(commandString, model, this.SQLUnitOfWork,
                                        this.Validator, this.Writer, this.Reader);

                try
                {
                    if (input.ToLower().Contains("exit"))
                    {
                        this.UpdateUserLog(currentUserId);
                    }
                    command.Execute();
                    
                }

                catch (Exception ex)
                {
                    this.Writer.Write("Unsuccessful command execution, please try again");
                    this.Writer.Write(ex.Message);
                    continue;
                }

                if (input.ToLower().Contains("report"))
                {
                    this.AddReportToPostgreSQLDb(currentUserId);
                }
            }
        }

        private int GetCurrentUserId(string currentUserUsername)
        {
            var users = this.SQLUnitOfWork.UserRepository.Search(u => u.UserName == currentUserUsername).ToArray();
            var userId = -1;

            if (users.Length > 0)
            {
                userId = users[0].Id;
            }

            return userId;
        }

        private void AddUserLog(int currentUserId)
        {
            string username = this.SQLUnitOfWork.UserRepository.GetByID(currentUserId).UserName;
            Creator creator = this.PostgreSQLUnitOfWork.CreatorsRepository.Search(u => u.Username == username).ToArray()[0];

            var log = new Log()
            {
                fromDate = DateTime.Now
            };

            if (creator == null)
            {
                creator = new Creator()
                {
                    Username = username
                };

                creator.Logs.Add(log);
                this.PostgreSQLUnitOfWork.LogsRepository.Add(log);
                this.PostgreSQLUnitOfWork.CreatorsRepository.Add(creator);
                this.PostgreSQLUnitOfWork.Commit();
            }
            else
            {
                creator.Logs.Add(log);
                this.PostgreSQLUnitOfWork.LogsRepository.Add(log);
                this.PostgreSQLUnitOfWork.CreatorsRepository.Update(creator);
                this.PostgreSQLUnitOfWork.Commit();
            }
        }

        private void UpdateUserLog(int currentUserId)
        {
            string username = this.SQLUnitOfWork.UserRepository.GetByID(currentUserId).UserName;
            Creator creator = this.PostgreSQLUnitOfWork.CreatorsRepository.Search(u => u.Username == username).ToArray()[0];
            var log = creator.Logs.Last();
            log.toDate = DateTime.Now;
            this.PostgreSQLUnitOfWork.LogsRepository.Update(log);
            this.PostgreSQLUnitOfWork.Commit();
        }

        private void AddReportToPostgreSQLDb(int currentUserId)
        {
            string username = this.SQLUnitOfWork.UserRepository.GetByID(currentUserId).UserName;
            Creator creator = this.PostgreSQLUnitOfWork.CreatorsRepository.Search(u => u.Username == username).ToArray()[0];

            var report = new Report()
            {
                Date = DateTime.Now
            };

            if (creator == null)
            {
                creator = new Creator()
                {
                    Username = username
                };
                creator.Reports.Add(report);
                this.PostgreSQLUnitOfWork.ReportsRepository.Add(report);
                this.PostgreSQLUnitOfWork.CreatorsRepository.Add(creator);
                this.PostgreSQLUnitOfWork.Commit();
            }
            else
            {
                creator.Reports.Add(report);
                this.PostgreSQLUnitOfWork.ReportsRepository.Add(report);
                this.PostgreSQLUnitOfWork.CreatorsRepository.Update(creator);
                this.PostgreSQLUnitOfWork.Commit();
            }
        }
    }
}
