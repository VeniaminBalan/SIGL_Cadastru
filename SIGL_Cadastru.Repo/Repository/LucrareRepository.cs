using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;
using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Repository
{
    public class LucrareRepository : Repository<Lucrare>, ILucrareRepository
    {
        public LucrareRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void CreateLucrare(Lucrare lucrare)
        {
            Create(lucrare);
        }

        public void DeleteLucrare(Lucrare lucrare)
        {
            Delete(lucrare);
        }

        public async Task<IEnumerable<Lucrare>> GetAllByCerereIdAsync(Guid cerereId, bool trackChanges) =>
           await FindByCondition(l => l.Cerere.Id == cerereId, trackChanges).ToListAsync();
    }
}
