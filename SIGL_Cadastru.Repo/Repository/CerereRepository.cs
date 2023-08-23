using Contracts;
using Repository;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using Microsoft.EntityFrameworkCore;
using Query;

namespace SIGL_Cadastru.Repo.Repository
{


    public class CerereRepository : Repository<Cerere>, ICerereRepository
    {
        private readonly AppDbContext _appDbContext;
        public CerereRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateCerere(Cerere cerere) 
        {
            Create(cerere);
            Console.WriteLine("Cerere Repository");
        }

        public void DeleteCerere(Cerere cerere) => Delete(cerere);

        public async Task<IEnumerable<Cerere>> GetAllAync(CerereQueryParams queryParams, bool trackChanges) 
        {
            IQueryable<Cerere> queryableList = _appDbContext.Cerere
                .Include(c => c.Executant)
                .Include(c => c.Client)
                .Include(c => c.Responsabil)
                .Include(c => c.StatusList);

            if(!trackChanges)
                queryableList = queryableList.AsNoTracking();

            if (!string.IsNullOrEmpty(queryParams.NrCadastral)) 
            {
                queryableList = queryableList.Where(c =>
                c.NrCadastral.Contains(queryParams.NrCadastral));
            }



            return await queryableList
                .OrderBy(c => c.ValabilPanaLa)
                .ToListAsync();
        }

        public async Task<Cerere?> GetByIdAsync(Guid CerereId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(CerereId), trackChanges)
            .Include(c => c.Executant)
            .Include(c => c.Client)
            .Include(c => c.Responsabil)
            .Include(c => c.Lucrari)
            .Include(c => c.StatusList)
            .SingleOrDefaultAsync();


        public Task<IEnumerable<Cerere>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateCerere(Cerere cerere) => Update(cerere);
        public Task<Cerere?> UpdateCerereAsync(Guid Id, Cerere cerere) => UpdateAsync(Id, cerere);

    }
}
