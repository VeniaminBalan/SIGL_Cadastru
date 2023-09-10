using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasMany(c => c.Lucrari)
                .WithOne(l => l.Cerere)
                .HasForeignKey(l => l.CerereId);

            builder.HasMany(c => c.StatusList)
                .WithOne(l => l.Cerere)
                .HasForeignKey(s => s.CerereId);

        }
    }
}
