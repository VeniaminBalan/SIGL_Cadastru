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

    public async Task<IEnumerable<CerereDto>> GetAllAsync(bool trackChanges)
    {
        var cereri = await _repo.Cerere.GetAllAync(trackChanges);

        var cereriDto = cereri.Select(c => new CerereDto 
        {
            Id = c.Id,

            ClientId = c.ClientId,
            Client = string.Join(" ", c.Client.Nume, c.Client.Prenume),

            ResponsabilId = c.ResponsabilId,
            Responsabil = string.Join(" ", c.Responsabil.Nume, c.Responsabil.Prenume),

            ExecutantId= c.ExecutantId,
            Executant = string.Join(" ", c.Executant.Nume, c.Executant.Prenume),

            NrCadastral= c.NrCadastral,
            ValabilDeLa = c.ValabilDeLa,
            ValabilPanaLa= c.ValabilPanaLa,
            Eliberat = c.Eliberat,
            Prelungit = c.Prelungit,
            Respins = c.Respins,
            LaReceptie= c.LaReceptie,
            
            StareaCererii = SetStatus(c.ValabilDeLa, c.Respins, c.LaReceptie, c.Eliberat)
        });

        return cereriDto;
    }

    public async Task<CerereDto> GetById(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }


    private Status SetStatus(DateOnly ValabilDeLa, DateOnly? Respins, DateOnly? LaReceptie, DateOnly? Eliberat) 
    {
        DateOnly DateRespins;
        if (Respins is null)
            DateRespins = new DateOnly();
        else DateRespins = (DateOnly)Respins;

        DateOnly DateLaReceptie;
        if (Respins is null)
            DateLaReceptie = new DateOnly();
        else DateLaReceptie = (DateOnly)LaReceptie;

        DateOnly DateEliberat;
        if (Respins is null)
            DateEliberat = new DateOnly();
        else DateEliberat = (DateOnly)Eliberat;


        List<DateOnly> dates = new List<DateOnly>{ ValabilDeLa, DateRespins, DateLaReceptie, DateEliberat };
        dates.Sort();

        var last = dates.Last();

        if (last == ValabilDeLa)
            return Status.Inlucru;

        if (last == DateRespins)
            return Status.Respins;

        if(last == DateLaReceptie)
            return Status.LaReceptie;

        if(last == DateEliberat)
            return Status.Eliberat;

        throw new Exception("somethin went wrong in SetStatus method");
    }
}
