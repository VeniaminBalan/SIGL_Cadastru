using Contracts;
using Mappers;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;

namespace Services;

internal sealed class LucrareService : ILucrareService
{
    private readonly IRepositoryManager _repo;

    public LucrareService(IRepositoryManager repo)
    {
        _repo = repo;
    }

    public void CreateLucrare(Lucrare lucrare)
    {
        _repo.Lucrare.CreateLucrare(lucrare);
    }

    public void DeleteLucrare(Lucrare lucrare)
    {
        _repo.Lucrare.DeleteLucrare(lucrare);
    }

    public async Task<IList<LucrareDto>> GetAllByIdAsync(Guid cerereId, bool trackChanges)
    {
        var data = await _repo.Lucrare.GetAllByCerereIdAsync(cerereId, trackChanges);
        return data.Select(x => LucrareMapper.Map(x)).ToList();
    }
}
