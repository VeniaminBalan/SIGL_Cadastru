﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGL_Cadastru.Repo.Models;


namespace SIGL_Cadastru.Repo.DataBase.Configurations
{
    public class LucrareConfiguration : IEntityTypeConfiguration<Lucrare>
    {
        public void Configure(EntityTypeBuilder<Lucrare> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(l => l.Cerere)
                .WithMany(c => c.Lucrari)
                .HasForeignKey(l => l.CerereId);

        }
    }
}
