
using Contracts;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;

namespace SIGL_Cadastru.Tests.Mock;

internal class MockPersoanaRepository : IPersoanaRepository
{
    public void CreatePersoana(Persoana perosana)
    {
        throw new NotImplementedException();
    }

    public void DeletePersoana(Persoana perosana)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Persoana>> GetAllAync(PeopleQueryParams queryParams, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<Persoana> GetByIdAsync(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasDependencies(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> isIdnpUniqe(string idnp)
    {
        return Task.FromResult(true);
    }
}
