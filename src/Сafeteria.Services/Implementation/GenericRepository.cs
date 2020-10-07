using Cafeteria.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities.Abstraction;
using Сafeteria.Services.Abstraction;

namespace Сafeteria.Services.Implementation
{
    /// <summary>
    /// Represents set of basic instructions available for all repositories
    /// </summary>
    /// <typeparam name="TEntity">Type of entity repository is working with</typeparam>
    /// <typeparam name="TKey">Type of primary key of the entity</typeparam>
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        protected readonly CafeteriaDbContext _dbContext;

        public GenericRepository(CafeteriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual async Task Add(TEntity entity)
        {
            await _dbContext
                .Set<TEntity>()
                .AddAsync(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext
                .Set<TEntity>()
                .ToListAsync();
        }

        public virtual async Task<TEntity> Get(TKey id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(predicate);
        }

        public virtual async Task Remove(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Remove(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbContext
                .Set<TEntity>()
                .Update(entity);
        }
    }
}
