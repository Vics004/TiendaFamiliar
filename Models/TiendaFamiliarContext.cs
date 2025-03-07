using Microsoft.EntityFrameworkCore;

namespace TiendaFamiliarMVC.Models
{
    public class TiendaFamiliarContext : DbContext
    {
        public TiendaFamiliarContext(DbContextOptions<TiendaFamiliarContext> options) : base(options)
        {

        }

        public DbSet<Gastos> gastos { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Ganancias> ganancias { get; set; }
    }
}
