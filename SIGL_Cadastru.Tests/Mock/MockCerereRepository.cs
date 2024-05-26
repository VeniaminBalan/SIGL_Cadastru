using Contracts;
using Microsoft.EntityFrameworkCore;
using Query;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.ValueObjects;

namespace SIGL_Cadastru.Tests.Mock;

internal class MockCerereRepository : ICerereRepository
{
    public DbSet<Cerere> DbSet => throw new NotImplementedException();

    public void CreateCerere(Cerere cerere)
    {
        throw new NotImplementedException();
    }

    public void DeleteCerere(Cerere cerere)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cerere>> GetAllAync(CerereQueryParams queryParams, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Cerere> GetByIdAsync(Guid cerereId, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<NrCerere?> GetNextNumber()
    {
        return Task.FromResult(new NrCerere(DateTime.Now.Year, 1));
    }

    public void UpdateCerere(Cerere cerere)
    {
        throw new NotImplementedException();
    }
}
