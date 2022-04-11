using Microsoft.EntityFrameworkCore;
using ShopsRUs.IdentityServer.Settings.Context;
using ShopsRUs.IdentityServer.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using var context = new ShopsRUsContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new ShopsRUsContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new ShopsRUsContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ShopsRUsContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new ShopsRUsContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ShopsRUsContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using var context = new ShopsRUsContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new ShopsRUsContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new ShopsRUsContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new ShopsRUsContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

    }
}
