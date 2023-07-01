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
            Create(cerere);
            Console.WriteLine("Cerere Repository");
        }

        public void DeleteCerere(Cerere cerere) => Delete(cerere);

        public async Task<IEnumerable<Cerere>> GetAllAync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Include(c => c.Executant)
            .Include(c => c.Client)
            .Include(c => c.Responsabil)
            .OrderBy(c => c.ValabilPanaLa)
            .ToListAsync();

        public async Task<Cerere> GetByIdAsync(Guid CererId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(CererId), trackChanges)
            .Include(c => c.Executant)
            .Include(c => c.Client)
            .Include(c => c.Responsabil)
            .SingleOrDefaultAsync();

        public Task<IEnumerable<Cerere>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
