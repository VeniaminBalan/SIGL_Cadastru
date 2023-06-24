using Microsoft.EntityFrameworkCore;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Dosar> Dosare { get; set; }
        public DbSet<CerereDto> Cereri { get; set; }
        public DbSet<LucrareDto> Lucrari { get; set; }
        public DbSet<PersoanaDto> Persoane { get; set; }
    }
}
