using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GenericRepositoryAndUnitOfWorkCoreMVC_Demo.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int? id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
