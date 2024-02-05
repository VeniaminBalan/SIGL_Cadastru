using Contracts;
using Repository;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using Microsoft.EntityFrameworkCore;
using SIGL_Cadastru.Repo.Query.Extensions;
using Query;
using Exceptions;
using System.Collections.Generic;
using SIGL_Cadastru.Repo.ValueObjects;

namespace SIGL_Cadastru.Repo.Repository
{


    public class CerereRepository : Repository<Cerere>, ICerereRepository
    {
        public CerereRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }

        public DbSet<Cerere> DbSet => _appDbContext.Set<Cerere>();

        public void CreateCerere(Cerere cerere) => Create(cerere);

        public void DeleteCerere(Cerere cerere) => Delete(cerere);

        public async Task<IEnumerable<Cerere>> GetAllAync(CerereQueryParams queryParams, bool trackChanges) 
        {
            var query = FindAll(trackChanges)
                .Include(c => c.Executant)
                .Include(c => c.Client)
                .Include(c => c.Responsabil)
                .Include(c => c.StatusList)
                .AsQueryable();

            if (queryParams.Search is not null)
                query = query.SearchBy(queryParams.Search);

            if (queryParams.StateFilter is not null)
                query = query.FilterByState(queryParams.StateFilter);


            return await query
                .OrderBy(c => c.ValabilPanaLa)
                //.Sort(queryParams.SortParams)
                .ToListAsync();
        }


        public async Task<Cerere?> GetByIdAsync(Guid CerereId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(CerereId), trackChanges)
            .Include(c => c.Executant)
            .Include(c => c.Client)
            .Include(c => c.Responsabil)
            .Include(c => c.StatusList)
            .SingleOrDefaultAsync();

        public async Task<NrCerere?> GetLastNr() =>
            await FindAll(false)
            .OrderByDescending(c => c.CerereNr!.Year)
            .ThenByDescending(c => c.CerereNr!.Index)
            .Select(c => c.CerereNr)
            .FirstOrDefaultAsync();

        public void UpdateCerere(Cerere cerere) => Update(cerere);
        public Task<Cerere?> UpdateCerereAsync(Guid Id, Cerere cerere) => UpdateAsync(Id, cerere);

    }
}
