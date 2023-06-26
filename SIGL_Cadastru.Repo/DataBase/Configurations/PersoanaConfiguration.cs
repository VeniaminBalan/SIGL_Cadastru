using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGL_Cadastru.Repo.Models;


namespace SIGL_Cadastru.Repo.DataBase.Configurations
{
    internal class PersoanaConfiguration : IEntityTypeConfiguration<Persoana>
    {
        public void Configure(EntityTypeBuilder<Persoana> builder)
        {
            builder.HasData
                (
                    new Persoana
                    {
                        Id = new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"),
                        IDNP = "2000818343",
                        Nume = "Balan",
                        Prenume = "Octavian",
                        DataNasterii = new DateOnly(1977, 7, 16),
                        Domiciliu = "sat. Gribova",
                        Rol = Role.Responsabil
                    },

                    new Persoana
                    {
                        Id = new Guid("6eed1456-1b25-4195-9eda-e240a9ef09fd"),
                        IDNP = "2000818332",
                        Nume = "Gutu",
                        Prenume = "Ion",
                        DataNasterii = new DateOnly(1977, 7, 16),
                        Domiciliu = "sat. Pierduta",
                        Rol = Role.Client
                    }

                ) ;
        }
    }
}
