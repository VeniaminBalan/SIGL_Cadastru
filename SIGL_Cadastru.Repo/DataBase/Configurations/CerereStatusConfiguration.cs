using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace SIGL_Cadastru.Repo.DataBase.Configurations
{
    internal class CerereStatusConfiguration : IEntityTypeConfiguration<CerereStatus>
    {
        public void Configure(EntityTypeBuilder<CerereStatus> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(l => l.Cerere)
                .WithMany(c => c.StatusList)
                .HasForeignKey(l => l.CerereId);
        }
    }
}
