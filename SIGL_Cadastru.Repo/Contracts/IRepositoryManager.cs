
using Microsoft.EntityFrameworkCore;
using SIGL_Cadastru.Repo.DataBase;

namespace Contracts;

public interface IRepositoryManager
{
    public ICerereRepository Cerere { get; }
    public IPersoanaRepository Persoana { get; }

    public ICerereStatusRepository CerereStatus { get; }
    Task SaveAsync();
    public void DetachAll();
}
