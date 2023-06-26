using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIGL_Cadastru.Repo.Models;


namespace SIGL_Cadastru.Repo.DataBase.Configurations
{
    public class LucrareConfiguration : IEntityTypeConfiguration<Lucrare>
    {
        public void Configure(EntityTypeBuilder<Lucrare> builder)
        {
           
        }
    }
}
