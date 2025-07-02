using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<TipoProducto> TipoProducto { get; set; }

    }
}
