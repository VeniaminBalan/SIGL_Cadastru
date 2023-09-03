using Contracts;
using Microsoft.EntityFrameworkCore;
using Models;
using SIGL_Cadastru.Repo.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class CerereStatusRepository : Repository<CerereStatus>, ICerereStatusRepository
{
    public CerereStatusRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public void CreateCerere(CerereStatus cerere)
    {
        Create(cerere);
    }

    public void DeleteCerere(CerereStatus cerere) => Delete(cerere);

    public async Task<List<CerereStatus>> GetByIdAsync(Guid cerereId, bool trackChanges) =>
            await FindByCondition(c => c.Cerere.Id == cerereId, trackChanges)
        .OrderBy(c => c.Created)
        .ToListAsync();
}
