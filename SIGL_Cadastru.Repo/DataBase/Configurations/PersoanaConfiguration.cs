using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGL_Cadastru.Repo.Models;


namespace SIGL_Cadastru.Repo.DataBase.Configurations
{
    internal class PersoanaConfiguration : IEntityTypeConfiguration<Persoana>
    {
        public void Configure(EntityTypeBuilder<Persoana> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(p => p.Nume).HasMaxLength(50);
            builder.Property(p => p.Prenume).HasMaxLength(50);

            builder.Property(p => p.Email).HasMaxLength(255);
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.IDNP).IsUnique();
        }
    }
}
