using Contracts;
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
            throw new NotImplementedException();
        }

        public void DeleteLucrare(Lucrare lucrare)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lucrare>> GetAllAync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Lucrare> GetByIdAsync(Guid companyId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Lucrare>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
