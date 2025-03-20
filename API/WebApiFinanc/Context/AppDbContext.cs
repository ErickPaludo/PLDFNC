using Microsoft.EntityFrameworkCore;
using WebApiFinanc.Models;

namespace WebApiFinanc.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Gastos>? Gastos { get; set; }
        public DbSet<GastosStatus>? GastosStatus { get; set; }
    }
}
