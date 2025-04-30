using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs.Credito;

namespace WebApiFinanc.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Gastos>? Gastos { get; set; }
        public DbSet<Credito>? Credito { get; set; }
        public DbSet<Debito>? Debito { get; set; }
        public DbSet<GastosStatus>? GastosStatus { get; set; }
        public DbSet<Saldo>? Saldo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Credito>()
             .HasOne(c => c.Usuarios)
             .WithMany()
             .HasForeignKey(c => c.UserId)
             .IsRequired();

            builder.Entity<Debito>()
             .HasOne(c => c.Usuarios)
             .WithMany()
             .HasForeignKey(c => c.UserId)
             .IsRequired();  
            
            builder.Entity<Saldo>()
             .HasOne(c => c.Usuarios)
             .WithMany()
             .HasForeignKey(c => c.UserId)
             .IsRequired();

        }
    }
}
