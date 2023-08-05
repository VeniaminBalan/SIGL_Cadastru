using Contracts;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
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
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cerere>> GetAllAsync(bool trackChanges)
    {
        return await _repo.Cerere.GetAllAync(trackChanges);

    }

    public async Task<CerereDto> GetById(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Cerere cerere)
    {
        cerere.StareaCererii = SetStatus(cerere);
    }

    private Status SetStatus(Cerere cerere) 
    {
        DateOnly DateRespins;
        if (cerere.Respins is null)
            DateRespins = new DateOnly();
        else DateRespins = (DateOnly)cerere.Respins;

        DateOnly DateLaReceptie;
        if (cerere.LaReceptie is null)
            DateLaReceptie = new DateOnly();
        else DateLaReceptie = (DateOnly)cerere.LaReceptie;

        DateOnly DateEliberat;
        if (cerere.Eliberat is null)
            DateEliberat = new DateOnly();
        else DateEliberat = (DateOnly)cerere.Eliberat;


        List<DateOnly> dates = new List<DateOnly>{ cerere.ValabilDeLa, DateRespins, DateLaReceptie, DateEliberat };
        dates.Sort();

        var last = dates.Last();

        if (last == cerere.ValabilDeLa)
            return Status.Inlucru;

        if (last == DateRespins)
            return Status.Respins;

        if(last == DateLaReceptie)
            return Status.LaReceptie;

        if(last == DateEliberat)
            return Status.Eliberat;

        throw new Exception("something went wrong in SetStatus method");
    }
}
