using Contracts;
using Models;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.App.Mappers;
using SIGL_Cadastru.Repo.Models;

namespace Services;

internal sealed class CerereService : ICerereService
{
    private readonly IRepositoryManager _repo;

    public CerereService(IRepositoryManager repo)
    {
        _repo = repo;
    }

    public async Task CreateNewCerere(Cerere cerere)
    {
        _repo.Cerere.CreateCerere(cerere);
    }

    public async Task<IEnumerable<CerereDto>> GetAllAsync(bool trackChanges)
    {
        var data = await _repo.Cerere.GetAllAync(trackChanges);

        return data.Select(x => CerereMapper.Map(x)).ToList();

    }

    public async Task<CerereDto?> GetByIdAsync(Guid Id, bool trackChanges)
    {
        var data = await _repo.Cerere.GetByIdAsync(Id, trackChanges);

        if (data is null) return null;

        return CerereMapper.Map(data);
    }

}
