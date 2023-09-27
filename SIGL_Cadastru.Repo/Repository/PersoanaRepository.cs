using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;
using SQLitePCL;

namespace SIGL_Cadastru.Repo.Repository
{
    public class PersoanaRepository : Repository<Persoana>, IPersoanaRepository
    {
        private readonly AppDbContext _context;
        public PersoanaRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public void CreatePersoana(Persoana perosana) => Create(perosana);

        public void DeletePersoana(Persoana perosana) => Delete(perosana);

        public async Task<IEnumerable<Persoana>> GetAllAync(PeopleQueryParams queryParams, bool trackChanges)
        {

            IQueryable<Persoana>  peopleQuary = FindAll(trackChanges);

            if (!string.IsNullOrEmpty(queryParams.Search)) 
            {
                peopleQuary = peopleQuary.Where(p =>
                p.Nume.Contains(queryParams.Search) ||
                p.Prenume.Contains(queryParams.Search) ||
                p.IDNP.Contains(queryParams.Search));
            }

            if (queryParams.Rol is not null) 
            {
                peopleQuary = peopleQuary.Where(p => p.Rol == queryParams.Rol);
            }

            return await peopleQuary.ToListAsync();

        }

        public async Task<Persoana?> GetByIdAsync(Guid Id, bool trackChanges)=>
            await FindByCondition(e => e.Id.Equals(Id),trackChanges)
            .SingleOrDefaultAsync();


        public async Task<bool> isIdnpUniqe(string idnp)
        {
            var p = await FindByCondition(p => p.IDNP == idnp, false).FirstOrDefaultAsync();

            if (p is null)
                return true;

            return false;
        }

        public async Task<bool> HasDependencies(Guid Id) 
        {
            var p = await _appDbContext.Set<Cerere>()
                .Where(c => c.ClientId == Id)
                .AnyAsync();

            return p;
        }
    }
}
