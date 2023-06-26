using Contracts;
using Repository;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using Microsoft.EntityFrameworkCore;

namespace SIGL_Cadastru.Repo.Repository
{
    public class CerereRepository : Repository<Cerere>, ICerereRepository
    {
        public CerereRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void CreateCerere(Cerere cerere)
        {
            throw new NotImplementedException();
        }

        public void DeleteCerere(Cerere cerere)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cerere>> GetAllAync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.ValabilPanaLa)
            .ToListAsync();

        public Task<Cerere> GetByIdAsync(Guid companyId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cerere>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
