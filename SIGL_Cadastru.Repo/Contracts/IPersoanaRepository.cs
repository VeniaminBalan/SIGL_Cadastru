
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;

namespace Contracts;

public interface IPersoanaRepository
{
    Task<IEnumerable<Persoana>> GetAllAync(PeopleQueryParams queryParams,bool trackChanges);
    Task<Persoana> GetByIdAsync(Guid Id, bool trackChanges);
    void CreatePersoana(Persoana perosana);
    void DeletePersoana(Persoana perosana);
    Task<bool> isIdnpUniqe(string idnp);
}

