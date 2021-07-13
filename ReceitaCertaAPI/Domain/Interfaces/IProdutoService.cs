using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceitaCertaAPI.Domain.Interfaces
{
    using ReceitaCertaAPI.Domain.Models;

    public interface IProdutoService
    {
        public IEnumerable<Produto> GetAll();

        Task<Produto> GetById(int id);
        
        IEnumerable<Produto> GetByName(string name);
        
        Task Create(Produto entity);

        Task Update(int id, Produto entity);

        Task Delete(int id);
    }
}
