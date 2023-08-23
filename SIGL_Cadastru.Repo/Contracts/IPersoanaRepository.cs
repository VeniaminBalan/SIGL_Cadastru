

using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;

namespace Contracts;

public interface IPersoanaRepository
{
    Task<IEnumerable<Persoana>> GetAllAync(PeopleQueryParams queryParams,bool trackChanges);
    Task<Persoana> GetByIdAsync(Guid Id, bool trackChanges);
    Task<IEnumerable<Persoana>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreatePersoana(Persoana perosana);
    void DeletePersoana(Persoana perosana);

    Task<IEnumerable<Persoana>> GetAllExecutantiAync(bool trackChanges);
    Task<IEnumerable<Persoana>> GetAllResponsabiliAync(bool trackChanges);
    Task<IEnumerable<Persoana>> GetAllClientiAync(bool trackChanges);
}

