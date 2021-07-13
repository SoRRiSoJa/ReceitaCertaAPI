
namespace ReceitaCertaAPI.Persistence.Repositories
{
    using ReceitaCertaAPI.Domain.Models;
    using ReceitaCertaAPI.Domain.Repositories;
    using ReceitaCertaAPI.Persistence.Data;

    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ReceitaContext _recitaContext) : base(_recitaContext)
        {
        }
    }
}
