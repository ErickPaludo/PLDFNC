
using Microsoft.EntityFrameworkCore;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs;

namespace WebApiFinanc.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<CreditoDTO>? Credito { get; set; }
        public DbSet<DebitoDTO>? Debito { get; set; }
        public DbSet<Gastos>? Gastos { get; set; }
    }
}
