﻿namespace BusSeatsReservation.Commands.UsersCommands
{
    using Contracts;
    using Data.Common;
    using Models.SQL.Models;
    using System.Collections.Generic;
    using Utils;

    internal class CreateUserCommand : ICommand
    {
        public CreateUserCommand(EfUnitOfWork unitOfWork, IValidator validator)
        {
            this.UnitOfWork = unitOfWork;
            this.Validator = Validator;
        }

        public EfUnitOfWork UnitOfWork { get; protected set; }
        public IValidator Validator { get; protected set; }

        public string Execute(IList<string> parameters)
        {
            return $"{Constants.CreateUser}\n{Constants.AskForUserName}";
        }

        public void Create(User user)
        {
            this.Validator.Validate(user);
            this.UnitOfWork.UserRepository.Add(user);
        }
    }
}
