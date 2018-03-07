using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mediator.Domain.Contracts.Repositories{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {       
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}