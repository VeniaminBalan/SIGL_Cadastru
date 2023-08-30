using Contracts;
using Exceptions;
using Query;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;
using Extensions;
using SIGL_Cadastru.App.Mappers;
using SIGL_Cadastru.App.Entities;

namespace Services;


internal sealed class CerereService : ICerereService
{
    private readonly IRepositoryManager _repo;

    public CerereService(IRepositoryManager repo)
    {
        _repo = repo;
    }

    public void CreateNewCerere(Cerere cerere)
    {
        _repo.Cerere.CreateCerere(cerere);
    }

    public async Task<IEnumerable<CerereDto>> GetAllAsync(CerereQueryParams queryParams, bool trackChanges)
    {
        var data = await _repo.Cerere.GetAllAync(trackChanges);

        if (queryParams.TimeFilter is not null)
            data = data.FilterBy(queryParams.TimeFilter).ToList();

        var ret = data.Select(CerereMapper.Map);

        if(queryParams.StateFilter is not null)
            ret = ret.FilterByState(queryParams.StateFilter);

        if (queryParams.Search is not null)
            ret = ret.SearchBy(queryParams.Search).ToList();



        return ret;

    }

    public async Task<Cerere?> GetByIdAsync(Guid Id, bool trackChanges)
    {
        var data = await _repo.Cerere.GetByIdAsync(Id, trackChanges);

        if (data is null) 
            throw new CerereNotFoundException("Cererea nu a fost gasita");

        return data;
    }

    public void UpdateCerere(Cerere cerere)
    {

        _repo.Cerere.UpdateCerere(cerere);
    }

    public Task<Cerere> UpdateCerereAsync(Guid Id, Cerere cerere)
    {
        return _repo.Cerere.UpdateCerereAsync(Id, cerere);
    }
}
