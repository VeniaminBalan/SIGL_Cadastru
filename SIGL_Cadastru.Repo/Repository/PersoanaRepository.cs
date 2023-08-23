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

        public void CreatePersoana(Persoana perosana)
        {
            throw new NotImplementedException();
        }

        public void DeletePersoana(Persoana perosana)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Persoana>> GetAllAync(PeopleQueryParams queryParams, bool trackChanges)
        {

            IQueryable<Persoana>  peopleQuary = _context.Persoane;

            if (!trackChanges)
                peopleQuary = peopleQuary.AsNoTracking();

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
