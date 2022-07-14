using Microsoft.EntityFrameworkCore;
namespace Aula29.Models
{
    public class CatalogoContext : DbContext 
    {
        public CatalogoContext (DbContextOptions<CatalogoContext> options)
            : base(options) 
        {
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Ator> Atores { get; set; }
    }
}
