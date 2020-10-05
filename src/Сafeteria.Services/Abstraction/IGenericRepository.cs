using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Сafeteria.DataModels.Entities.Abstraction;

namespace Сafeteria.Services.Abstraction
{
    /// <summary>
    /// Represents set of basic instructions available for all repositories
    /// </summary>
    /// <typeparam name="TEntity">Type of entity repository is working with</typeparam>
    /// <typeparam name="TKey">Type of primary key of the entity</typeparam>
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        Task Add(TEntity entity);
        Task<TEntity> Get(TKey id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
    }
}
