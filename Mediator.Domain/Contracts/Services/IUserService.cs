using System;
using System.Collections.Generic;
using Mediator.Domain.Entities;

namespace Mediator.Domain.Services{

    public interface IUserService
    {
        void Add(User entity);
        User GetById(Guid id);
        IEnumerable<User> GetAll();
        void Update(User entity);
        void Remove(Guid id);
    }
}