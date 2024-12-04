using HDI.Models;
using Microsoft.EntityFrameworkCore;

namespace HDI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ordenes> ordenes { get; set; }
        public DbSet<Almacen> Almacen {  get; set; }

        public DbSet<CatEstatusOrden> CatEstatusOrden { get; set; }

        public DbSet<Mesas> Mesas { get; set; }

        public DbSet<OrdenesDetalle> OrdenesDetalle { get; set; }

        public DbSet<Producto> Producto { get; set; }

    }
}
