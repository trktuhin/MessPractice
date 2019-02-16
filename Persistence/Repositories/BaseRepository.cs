using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mess.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Mess.Persistence.Repositories
{
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity:class
    {
        protected readonly DbSet<TEntity> _entities;

        protected readonly MessDbContext _context;
        public BaseRepository(DbContext context)
        {
            _entities=context.Set<TEntity>();
            _context=context as MessDbContext;
        }

        public TEntity Add(TEntity entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            var addRange = entities as TEntity[] ?? entities.ToArray();
            _entities.AddRange(addRange);

            return addRange;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }
    }
}