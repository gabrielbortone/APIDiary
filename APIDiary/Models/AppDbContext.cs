using APIDiary.Models.ValueType;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIDiary.Models
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>()
                .HasMany(u => u.Entradas)
                .WithOne(e => e.Usuario)
                .IsRequired();

            builder.Entity<Entrada>()
                .HasMany(e => e.Imagens)
                .WithOne(i => i.Entrada)
                .IsRequired(false);
        }
    }
}
