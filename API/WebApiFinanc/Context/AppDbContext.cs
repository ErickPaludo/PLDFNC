
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
        public DbSet<Credito>? Credito { get; set; }
      //  public DbSet<CreditoFixo>? CreditoFixo { get; set; }
        public DbSet<Debito>? Debito { get; set; }
        public DbSet<DebitoFixo>? DebitoFixo { get; set; }
      //  public DbSet<Investimentos>? Investimentos { get; set; }
    }
}
