using Query;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;


namespace SIGL_Cadastru.App.Contracts;
public interface ICerereService
{
    public void CreateNewCerere(Cerere cerere);
    public void UpdateCerere(Cerere cerere);
    public Task DeleteCerere(Guid id);
    public Task<IEnumerable<CerereDto>> GetAllAsync(CerereQueryParams queryParams, bool trackChanges);
    public Task<Cerere?> GetByIdAsync(Guid Id, bool trackChanges);
}