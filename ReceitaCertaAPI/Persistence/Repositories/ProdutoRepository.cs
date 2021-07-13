using System.Collections.Generic;
using System.Linq;

namespace ReceitaCertaAPI.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using ReceitaCertaAPI.Domain.Models;
    using ReceitaCertaAPI.Domain.Repositories;
    using ReceitaCertaAPI.Persistence.Data;
    using System.Threading.Tasks;

    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ReceitaContext _recitaContext) : base(_recitaContext)
        {
        }


        public   IEnumerable<Produto> GetByName(string name)
        {
            return   _recitaContext.Produto.Where(x=>x.Nome.Contains(name));
        }
    }
}
