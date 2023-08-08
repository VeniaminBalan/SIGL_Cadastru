using SIGL_Cadastru.Repo.Models;

namespace Contracts;

public interface ILucrareRepository
{
    Task<IEnumerable<Lucrare>> GetAllByIdAsync(Guid cerereId, bool trackChanges);
    void CreateLucrare(Lucrare lucrare);
    void DeleteLucrare(Lucrare lucrare);
}
