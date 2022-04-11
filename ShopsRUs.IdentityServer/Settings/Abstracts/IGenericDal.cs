using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Interfaces
{
    public interface IGenericDal<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector);
        Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByUUIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
