using SIGL_Cadastru.Repo.Models;

namespace Contracts;

public interface ILucrareRepository
{
    Task<IEnumerable<Lucrare>> GetAllAync(bool trackChanges);
    Task<Lucrare> GetByIdAsync(Guid companyId, bool trackChanges);
    Task<IEnumerable<Lucrare>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    void CreateLucrare(Lucrare lucrare);
    void DeleteLucrare(Lucrare lucrare);
}
