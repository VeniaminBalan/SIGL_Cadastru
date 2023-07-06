using Contracts;
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
    private Lazy<ILucrareRepository> _lucrareRepository;
    private Lazy<IPersoanaRepository> _perosanaRepository;

    public RepositoryManager(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        _cerereRepository = new Lazy<ICerereRepository>(() => new CerereRepository(_appDbContext));
        _lucrareRepository = new Lazy<ILucrareRepository>(() => new LucrareRepository(_appDbContext));
        _perosanaRepository = new Lazy<IPersoanaRepository>(() => new PersoanaRepository(_appDbContext));

    }

    public ICerereRepository Cerere => _cerereRepository.Value;
    public ILucrareRepository Lucrare => _lucrareRepository.Value;
    public IPersoanaRepository Persoana=> _perosanaRepository.Value;

    public Task SaveAsync() => _appDbContext.SaveChangesAsync();
}
