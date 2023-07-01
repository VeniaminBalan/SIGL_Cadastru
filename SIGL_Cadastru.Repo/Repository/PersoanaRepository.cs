using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.Repository
{
    public class PersoanaRepository : Repository<Persoana>, IPersoanaRepository
    {
        public PersoanaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void CreatePersoana(Persoana perosana)
        {
            throw new NotImplementedException();
        }

        public void DeletePersoana(Persoana perosana)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persoana>> GetAllAync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Persoana>> GetAllClientiAync(bool trackChanges)
        {
            var clienti = await FindAll(trackChanges)
                .Where(p => p.Rol == Role.Client)
                .ToListAsync();

            return clienti;
        }

        public async Task<IEnumerable<Persoana>> GetAllExecutantiAync(bool trackChanges)
        {
            var responsabil = await FindAll(trackChanges)
                .Where(p => p.Rol == Role.Responsabil || p.Rol == Role.Executant)
                .ToListAsync();

            return responsabil;
        }

        public async Task<IEnumerable<Persoana>> GetAllResponsabiliAync(bool trackChanges)
        {
            var responsabil = await FindAll(trackChanges)
                .Where(p => p.Rol == Role.Responsabil)
                .ToListAsync();

            return responsabil;
        }

        public async Task<Persoana> GetByIdAsync(Guid Id, bool trackChanges)=>
            await FindByCondition(e => e.Id.Equals(Id),trackChanges)
            .SingleOrDefaultAsync();

        public Task<IEnumerable<Persoana>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
