using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceitaCertaAPI.Persistence.Repositories
{
    using ReceitaCertaAPI.Domain.Repositories;
    using ReceitaCertaAPI.Persistence.Data;
    using System.Linq;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
    {
        protected readonly ReceitaContext _recitaContext;
        public GenericRepository(ReceitaContext _recitaContext)
        {
            this._recitaContext = _recitaContext ?? throw new ArgumentNullException(nameof(_recitaContext));
        }
        public async Task Create(TEntity entity)
        {
            await _recitaContext.Set<TEntity>().AddAsync(entity);
            await _recitaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _recitaContext.Set<TEntity>().Remove(entity);
            await _recitaContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _recitaContext.Set<TEntity>().AsNoTracking();
        }
        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return _recitaContext.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _recitaContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            _recitaContext.Set<TEntity>().Update(entity);
            await _recitaContext.SaveChangesAsync();
        }
    }
}
