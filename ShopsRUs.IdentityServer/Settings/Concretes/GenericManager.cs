using ShopsRUs.IdentityServer.Settings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopsRUs.IdentityServer.Settings.Repositories
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _genericDal.AddAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<TEntity> GetByUUIdAsync(Guid id)
        {
            return await _genericDal.GetByUUIdAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDal.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
