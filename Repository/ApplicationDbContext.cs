using Microsoft.EntityFrameworkCore;
using teste.Entidade;

namespace teste.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        }

        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Abastecimento> Abastecimento { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}