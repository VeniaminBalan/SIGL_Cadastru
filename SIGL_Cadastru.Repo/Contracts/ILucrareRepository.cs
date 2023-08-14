using SIGL_Cadastru.Repo.Models;

namespace Contracts;

public interface ILucrareRepository
{
    Task<IEnumerable<Lucrare>> GetAllByCerereIdAsync(Guid cerereId, bool trackChanges);
    void CreateLucrare(Lucrare lucrare);
    void DeleteLucrare(Lucrare lucrare);
}
