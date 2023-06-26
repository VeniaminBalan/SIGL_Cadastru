using Microsoft.EntityFrameworkCore;
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
            modelBuilder
                 .Entity<Cerere>()
                 .ToTable(b => b.HasCheckConstraint("CK_NrCadstral", "LENGTH(NrCadastral) <= 15"));

            modelBuilder.ApplyConfiguration(new PersoanaConfiguration());
            modelBuilder.ApplyConfiguration(new CereriConfiguration());
        }

        public DbSet<Cerere> Cereri { get; set; }
        public DbSet<Lucrare> Lucrari { get; set; }
        public DbSet<Persoana> Persoane { get; set; }
    }


}
