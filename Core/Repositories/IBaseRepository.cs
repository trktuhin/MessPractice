using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mess.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
         TEntity Add(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);


        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);


        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();


        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}