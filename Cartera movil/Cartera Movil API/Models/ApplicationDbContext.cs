using Microsoft.EntityFrameworkCore;

namespace Cartera_movil_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartera> Carteras { get; set; }
    }
}
