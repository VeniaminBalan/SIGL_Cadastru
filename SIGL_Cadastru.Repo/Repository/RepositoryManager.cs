using Contracts;
using Microsoft.EntityFrameworkCore;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;


public class RepositoryManager : IRepositoryManager
{
    private readonly AppDbContext _appDbContext;

    private Lazy<ICerereRepository> _cerereRepository;
    private Lazy<IPersoanaRepository> _perosanaRepository;
    private Lazy<ICerereStatusRepository> _cerereStatusRepository;

    public RepositoryManager(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        _cerereRepository = new Lazy<ICerereRepository>(() => new CerereRepository(_appDbContext));
        _perosanaRepository = new Lazy<IPersoanaRepository>(() => new PersoanaRepository(_appDbContext));
        _cerereStatusRepository = new Lazy<ICerereStatusRepository>(() => new CerereStatusRepository(_appDbContext));

    }

    public ICerereRepository Cerere => _cerereRepository.Value;
    public IPersoanaRepository Persoana=> _perosanaRepository.Value;
    public ICerereStatusRepository CerereStatus=> _cerereStatusRepository.Value;
    public void DetachAll() => _appDbContext.ChangeTracker.Clear();
    public Task SaveAsync() => _appDbContext.SaveChangesAsync();
}
