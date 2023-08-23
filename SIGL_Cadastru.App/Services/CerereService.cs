using Contracts;
using Models;
using Query;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.App.Exceptions;
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

    public void CreateNewCerere(Cerere cerere)
    {
        _repo.Cerere.CreateCerere(cerere);
    }

    public async Task<IEnumerable<Cerere>> GetAllAsync(CerereQueryParams queryParams, bool trackChanges)
    {
        var data = await _repo.Cerere.GetAllAync(queryParams,trackChanges);

        return data;

    }

    public async Task<Cerere?> GetByIdAsync(Guid Id, bool trackChanges)
    {
        var data = await _repo.Cerere.GetByIdAsync(Id, trackChanges);

        if (data is null) 
            throw new CerereNotFoundException();

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
