using Contracts;
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

        public Task<Persoana> GetByIdAsync(Guid companyId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Persoana>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
