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


            builder.HasData(

                    new Persoana(
                            Guid.NewGuid(),
                            "Balan",
                            "Octavian",
                            "124353452341",
                            DateOnly.Parse("1977-07-16"),
                            "sat. Gribova",
                            "geoproiectgrup@mail.ru",
                            "079900218",
                            Role.Responsabil ),

                    new Persoana(
                            Guid.NewGuid(),
                            "Balan",
                            "Veniamin",
                            "2002500081628",
                            DateOnly.Parse("2002-08-13"),
                            "or. Drochia",
                            "",
                            "079900846",
                            Role.Client)                       

                );
        }
    }
}
