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
          
        }
    }
}
