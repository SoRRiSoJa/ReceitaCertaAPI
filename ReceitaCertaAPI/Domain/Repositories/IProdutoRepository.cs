using ReceitaCertaAPI.Domain.Models;
using System.Collections.Generic;

namespace ReceitaCertaAPI.Domain.Repositories
{
    public interface IProdutoRepository : IGenericRepository<Produto>
    {
        IEnumerable<Produto> GetByName(string name);
    }
}
