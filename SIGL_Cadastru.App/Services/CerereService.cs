using Contracts;
using Models;
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
        var data = await _repo.Cerere.GetAllAync(trackChanges);

        return data.Select(x => new CerereDto 
        {
            Id= x.Id,
            ResponsabilId= x.ResponsabilId,
            Responsabil = string.Join(' ', x.Responsabil.Nume, x.Responsabil.Prenume),

            ExecutantId = x.ExecutantId,
            Executant = string.Join(' ', x.Executant.Nume, x.Executant.Prenume),

            ClientId = x.ClientId,
            Client = string.Join(' ', x.Client.Nume, x.Client.Prenume),

            NrCadastral= x.NrCadastral,
            ValabilDeLa=x.ValabilDeLa,
            ValabilPanaLa=x.ValabilPanaLa,

            StareaCererii = SetStatus(x.StatusList),
            LaReceptie = GetDate(x.StatusList, Status.LaReceptie),
            Eliberat = GetDate(x.StatusList, Status.Eliberat),
            Respins = GetDate(x.StatusList, Status.Respins)


        }).ToList();

    }

    public async Task<CerereDto> GetById(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }


    private Status SetStatus(List<CerereStatus> stari) 
    {
        var state = stari.OrderByDescending(x => x.Created).First();
        return state.Starea;           
    }

    private DateOnly? GetDate(List<CerereStatus> stari, Status status) 
    {
        var state = stari.OrderByDescending(x => x.Created).FirstOrDefault(d => d.Starea == status);

        if (state is null) 
            return null;

        return state.Created;
    }

}
