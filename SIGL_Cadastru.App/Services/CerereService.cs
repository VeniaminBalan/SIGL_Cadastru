using Contracts;
using Exceptions;
using Query;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;
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

    public async Task DeleteCerere(Guid id)
    {
        var cerere = await _repo.Cerere.GetByIdAsync(id, true);

        if(cerere is null)
            throw new CerereNotFoundException("Cererea nu a fost gasita");

        _repo.Cerere.DeleteCerere(cerere);
        await _repo.SaveAsync();
    }

    public async Task<IEnumerable<CerereDto>> GetAllAsync(CerereQueryParams queryParams, bool trackChanges)
    {
        var data = await _repo.Cerere.GetAllAync(queryParams, trackChanges);

        //if (queryParams.TimeFilter is not null)
        //    data = data.FilterBy(queryParams.TimeFilter).ToList();


        //if(queryParams.StateFilter is not null)
        //    ret = ret.FilterByState(queryParams.StateFilter);

        //if (queryParams.Search is not null)
        //    ret = ret.SearchBy(queryParams.Search).ToList();



        return data.Select(CerereMapper.Map);

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

}
