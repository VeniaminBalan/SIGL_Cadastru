
using Microsoft.EntityFrameworkCore;
using SIGL_Cadastru.Repo.DataBase;

namespace Contracts;

public interface IRepositoryManager
{
    DbContext context { get; }
    ICerereRepository Cerere { get; }
    IPersoanaRepository Persoana { get; }
    ICerereStatusRepository CerereStatus { get; }
    Task SaveAsync();
    void DetachAll();
}
