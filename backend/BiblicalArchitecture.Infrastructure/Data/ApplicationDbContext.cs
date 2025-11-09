using BiblicalArchitecture.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BiblicalArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<ExemploBiblico> ExemplosBiblicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações do modelo podem ser adicionadas aqui
            modelBuilder.Entity<Modulo>()
                .HasMany(m => m.Aulas)
                .WithOne(a => a.Modulo)
                .HasForeignKey(a => a.ModuloId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Modulo>()
                .HasMany(m => m.Exemplos)
                .WithOne(e => e.Modulo)
                .HasForeignKey(e => e.ModuloId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
