using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceitaCertaAPI.Domain.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll();

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);

        Task<TEntity> GetById(int id);

        Task Create(TEntity entity);

        Task Update(int id, TEntity entity);

        Task Delete(int id);
    }
}
