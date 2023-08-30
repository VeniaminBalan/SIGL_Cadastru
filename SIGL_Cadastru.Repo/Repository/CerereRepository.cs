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

        public void CreateCerere(Cerere cerere) => Create(cerere);

        public void DeleteCerere(Cerere cerere) => Delete(cerere);

        public async Task<IEnumerable<Cerere>> GetAllAync(bool trackChanges) =>
            await FindAll(trackChanges)
                .Include(c => c.Executant)
                .Include(c => c.Client)
                .Include(c => c.Responsabil)
                .Include(c => c.StatusList)
                .OrderBy(c => c.ValabilPanaLa)
                .ToListAsync();

        public async Task<Cerere?> GetByIdAsync(Guid CerereId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(CerereId), trackChanges)
            .Include(c => c.Executant)
            .Include(c => c.Client)
            .Include(c => c.Responsabil)
            .Include(c => c.Lucrari)
            .Include(c => c.StatusList)
            .SingleOrDefaultAsync();


        public void UpdateCerere(Cerere cerere) => Update(cerere);
        public Task<Cerere?> UpdateCerereAsync(Guid Id, Cerere cerere) => UpdateAsync(Id, cerere);

    }
}
