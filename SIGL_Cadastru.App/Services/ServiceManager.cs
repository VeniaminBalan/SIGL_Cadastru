using Contracts;
using SIGL_Cadastru.App.Contracts;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    
    private readonly Lazy<ICerereService> _cerereService;
    private readonly Lazy<ILucrareService> _lucrareService;
    private readonly Lazy<IPersoanaService> _persoanaService;

    public ServiceManager(IRepositoryManager repoManager)
    {

        _cerereService = new Lazy<ICerereService>(() => new CerereService(repoManager));
        _lucrareService = new Lazy<ILucrareService>(() => new LucrareService(repoManager));
        _persoanaService = new Lazy<IPersoanaService>(() => new PersoanaService(repoManager));
    }

    public ICerereService CerereService => _cerereService.Value;
    public IPersoanaService PersoanaService => _persoanaService.Value;
    public ILucrareService lucrareService => _lucrareService.Value;
}
