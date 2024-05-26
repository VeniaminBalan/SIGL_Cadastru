using Microsoft.EntityFrameworkCore;
using Query;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.ValueObjects;

namespace Contracts;

public interface ICerereRepository
{
    DbSet<Cerere> DbSet { get; }
    Task<IEnumerable<Cerere>> GetAllAync(CerereQueryParams queryParams, bool trackChanges);
    Task<Cerere> GetByIdAsync(Guid cerereId, bool trackChanges);
    void CreateCerere(Cerere cerere);
    void DeleteCerere(Cerere cerere);
    void UpdateCerere(Cerere cerere);
    public Task<NrCerere> GetNextNumber();
}
