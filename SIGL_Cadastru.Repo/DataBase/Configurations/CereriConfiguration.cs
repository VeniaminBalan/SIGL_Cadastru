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

            builder.HasData
                (
                    new Cerere
                    {
                        Id = new Guid("f5bb1dbe-a8cc-4d8b-89aa-3f5a595a7546"),
                        NrCadastral = "36011010001",
                        ValabilDeLa = new DateOnly(2023, 6, 26),
                        ValabilPanaLa = new DateOnly(2023, 7, 7),
                        CostTotal = 9999,
                        ClientId = new Guid("6eed1456-1b25-4195-9eda-e240a9ef09fd"),
                        ResponsabilId = new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3"),
                        ExecutantId = new Guid("d8f68da7-402b-411f-b6ea-a16beaf005e3")
                    }
                );
        }
    }
}
