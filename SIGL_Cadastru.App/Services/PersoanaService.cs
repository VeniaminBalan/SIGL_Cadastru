using Contracts;
using Mappers;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;

namespace Services;


internal sealed class PersoanaService : IPersoanaService
{

    private readonly IRepositoryManager _repo;

    public PersoanaService(IRepositoryManager repo)
    {
        _repo = repo;
    }

    public void CreatePersoana(Persoana perosana)
    {
        _repo.Persoana.CreatePersoana(perosana);
    }

    public void DeletePersoana(Persoana perosana)
    {
        _repo.Persoana.DeletePersoana(perosana);
    }

    public async Task<IEnumerable<PersoanaDto>> GetAllAync(bool trackChanges)
    {
        var data = await _repo.Persoana.GetAllAync(trackChanges);

        return data.Select(x => PersoanaMapper.Map(x));
    }

    public async Task<IEnumerable<PersoanaDto>> GetAllClientiAync(bool trackChanges)
    {
        var data = await _repo.Persoana.GetAllClientiAync(trackChanges);
        return data.Select(x => PersoanaMapper.Map(x));
    }

    public async Task<IEnumerable<PersoanaDto>> GetAllExecutantiAync(bool trackChanges)
    {
        var data = await _repo.Persoana.GetAllExecutantiAync(trackChanges);
        return data.Select(x => PersoanaMapper.Map(x));
    }

    public async Task<IEnumerable<PersoanaDto>> GetAllResponsabiliAync(bool trackChanges)
    {
        var data = await _repo.Persoana.GetAllResponsabiliAync(trackChanges);
        return data.Select(x => PersoanaMapper.Map(x));
    }

    public async Task<PersoanaDto> GetByIdAsync(Guid Id, bool trackChanges)
    {
        var data = await _repo.Persoana.GetByIdAsync(Id, trackChanges);

        return PersoanaMapper.Map(data);
    }

    public async Task<IEnumerable<PersoanaDto>> getByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        var data = await _repo.Persoana.getByIdsAsync(ids, trackChanges);

        return data.Select(x => PersoanaMapper.Map(x));
    }
}
