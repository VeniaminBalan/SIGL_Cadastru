using Microsoft.EntityFrameworkCore;
using Models;
using SIGL_Cadastru.Repo.DataBase.Configurations;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite();
        }

        public DbSet<Cerere> Cereri { get; set; }
        public DbSet<Lucrare> Lucrari { get; set; }
        public DbSet<Persoana> Persoane { get; set; }
        public DbSet<CerereStatus> Stari { get; set; }
    }


}
