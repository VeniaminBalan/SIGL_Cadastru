using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.App.Contracts;

public interface ICerereService
{
    public Task CreateNewCerere(Cerere cerere);
    public Task<IEnumerable<Cerere>> GetAllAsync(bool trackChanges);
    public Task<CerereDto> GetById(Guid Id, bool trackChanges);

    public Task Update(Cerere cerere);
}