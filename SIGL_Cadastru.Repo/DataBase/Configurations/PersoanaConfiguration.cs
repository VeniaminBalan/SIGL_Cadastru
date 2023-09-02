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
                    new Persoana(
                        new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"),
                        "Balan",
                        "Octavian",
                        "2000818343",
                        new DateOnly(1977, 7, 16),
                        "sat. Gribova",
                        null,
                        null,
                        Role.Responsabil
                        )
                ) ;
        }
    }
}
