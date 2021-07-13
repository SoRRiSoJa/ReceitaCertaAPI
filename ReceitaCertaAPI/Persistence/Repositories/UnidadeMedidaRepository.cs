namespace ReceitaCertaAPI.Persistence.Repositories
{
    using ReceitaCertaAPI.Domain.Models;
    using ReceitaCertaAPI.Domain.Repositories;
    using ReceitaCertaAPI.Persistence.Data;

    public class UnidadeMedidaRepository : GenericRepository<UnidadeMedida>, IUnidadeMedidaRepository
    {
        public UnidadeMedidaRepository(ReceitaContext _recitaContext) : base(_recitaContext)
        {
        }
    }
}
