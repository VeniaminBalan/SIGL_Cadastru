using Models;
using SIGL_Cadastru.App.Entities.DataTransferObjects;


namespace SIGL_Cadastru.App.Contracts;

public interface ICerereStatusService
{
    Task<List<CerereStatusDto>> GetByIdAsync(Guid cerereId, bool trackChanges);
    void CreateCerere(CerereStatus cerere);
    void DeleteCerere(CerereStatus cerere);
}
