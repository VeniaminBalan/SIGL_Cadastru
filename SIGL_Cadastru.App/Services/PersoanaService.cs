using Contracts;
using Mappers;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;


namespace SIGL_Cadastru.App.Services;

public sealed class PersoanaService : IPersoanaService
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

    public async Task<IEnumerable<PersoanaDto>> GetAllAync(PeopleQueryParams queryParams,bool trackChanges)
    {
        var data = await _repo.Persoana.GetAllAync(queryParams,trackChanges);

        return data.Select(x => PersoanaMapper.Map(x));
    }

    public async Task<PersoanaDto> GetByIdAsync(Guid Id, bool trackChanges)
    {
        var data = await _repo.Persoana.GetByIdAsync(Id, trackChanges);

        return PersoanaMapper.Map(data);
    }

}
