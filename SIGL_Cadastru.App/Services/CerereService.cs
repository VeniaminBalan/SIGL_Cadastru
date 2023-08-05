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
            Client = string.Join(' ', x.Executant.Nume, x.Executant.Prenume),

            NrCadastral= x.NrCadastral,
            ValabilDeLa=x.ValabilDeLa,
            ValabilPanaLa=x.ValabilPanaLa,
        });

    }

    public async Task<CerereDto> GetById(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
