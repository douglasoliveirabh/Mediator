using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mediator.Domain.Contracts.Repositories;
using Mediator.Domain.Entities;

namespace Mediator.Infra.Data.Repositories {

    public class FakeUserRepository : IUserRepository
    {
        public void Add(User entity)
        {
            
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return new List<User>();
        }

        public IEnumerable<User> GetAll()
        {
             return new List<User>();
        }

        public User GetById(Guid id)
        {
            return new User();
        }

        public void Remove(Guid id)
        {
            
        }

        public void Update(User entity)
        {
                      
        }
    }
}