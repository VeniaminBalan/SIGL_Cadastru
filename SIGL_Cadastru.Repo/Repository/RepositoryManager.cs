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
    }

    public ICerereRepository Cerere {
        get 
        {
            if (_cerereRepository is null)
                _cerereRepository = new CerereRepository(_appDbContext);

            return _cerereRepository;
        }
    }
    public ILucrareRepository Lucrare { 
        get
        {
            if (_lucrareRepository is null)
                _lucrareRepository = new LucrareRepository(_appDbContext);

            return _lucrareRepository;
        }
    }
    public IPersoanaRepository Persoana {
        get
        {
            if (_perosanaRepository is null)
                _perosanaRepository = new PersoanaRepository(_appDbContext);

            return _perosanaRepository;
        }
    }

    public Task SaveAsync() => _appDbContext.SaveChangesAsync();
}
