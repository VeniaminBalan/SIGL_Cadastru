using Contracts;
using Mappers;
using Models;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities.DataTransferObjects;


namespace SIGL_Cadastru.App.Services;

public class CerereStatusService : ICerereStatusService
{
    private readonly IRepositoryManager _repo;
    public CerereStatusService(IRepositoryManager repo)
    {
        _repo = repo;
    }
    public void CreateCerere(CerereStatus cerere)
    {
        _repo.CerereStatus.CreateCerere(cerere);
    }

    public void DeleteCerere(CerereStatus cerere)
    {
        _repo.CerereStatus.DeleteCerere(cerere);
    }

    public async Task<List<CerereStatusDto>> GetByIdAsync(Guid cerereId, bool trackChanges)
    {
        var data = await _repo.CerereStatus.GetByIdAsync(cerereId, trackChanges);

        return data.Select(x => CerereStatusMapper.Map(x)).ToList();
    }
}
