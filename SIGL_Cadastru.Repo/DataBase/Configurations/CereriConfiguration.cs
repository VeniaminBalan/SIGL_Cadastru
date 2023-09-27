using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using SIGL_Cadastru.Repo.DataBase.CustomConverters;
using SIGL_Cadastru.Repo.Models;

using Newtonsoft.Json;


namespace SIGL_Cadastru.Repo.DataBase.Configurations
{
    public class CereriConfiguration : IEntityTypeConfiguration<Cerere>
    {
        public void Configure(EntityTypeBuilder<Cerere> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(c => c.NrCadastral).HasMaxLength(15);
            builder.Property(c => c.Comment).HasMaxLength(255);

            builder.HasIndex(c => c.Nr)
                .IsUnique();

            builder.HasMany(c => c.StatusList)
                .WithOne(l => l.Cerere)
                .HasForeignKey(s => s.CerereId);
            


            var converter = new CustomPortofoliuConverter();

            builder.Property(c => c.Portofoliu)
                .HasConversion(p => JsonConvert.SerializeObject(p, converter),
                value => JsonConvert.DeserializeObject<Portofoliu>(value, converter));
        }
    }
}
