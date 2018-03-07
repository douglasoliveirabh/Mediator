using System;
using System.Collections.Generic;
using Mediator.Domain.Commands;
using Mediator.Domain.Contracts.Repositories;
using Mediator.Domain.Entities;
using Mediator.Domain.Services;
using Mediator.Shared.Mediator;

namespace Mediator.Application.Services{

    public class UserService : IUserService
    {
        IUserRepository _repository;
        IMediatorHandler _mediator;

        public UserService(IUserRepository repository, IMediatorHandler mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }


        public void Add(User entity)
        {
            var userCommand = new AddUserCommand(entity.Username, entity.Password, entity.Email);

            _mediator.SendCommand(userCommand);
            
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(Guid id)
        {
           return _repository.GetById(id);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}