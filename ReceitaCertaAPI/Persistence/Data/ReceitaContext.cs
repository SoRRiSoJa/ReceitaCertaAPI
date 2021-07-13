using Microsoft.EntityFrameworkCore;

namespace ReceitaCertaAPI.Persistence.Data
{
    using ReceitaCertaAPI.Domain.Models;
    public class ReceitaContext : DbContext
    {
        
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedida { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ReceitaContext(DbContextOptions<ReceitaContext> options) : base(options)
        {

        }

    }
}
