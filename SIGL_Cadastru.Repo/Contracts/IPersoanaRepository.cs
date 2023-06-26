

using SIGL_Cadastru.Repo.Models;

namespace Contracts;

public interface IPersoanaRepository
{
    Task<IEnumerable<Persoana>> GetAllAync(bool trackChanges);
    Task<Persoana> GetByIdAsync(Guid companyId, bool trackChanges);
    Task<IEnumerable<Persoana>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreatePersoana(Persoana perosana);
    void DeletePersoana(Persoana perosana);
}

