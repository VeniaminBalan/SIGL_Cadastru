﻿using Contracts;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Services;

namespace Services;

public sealed class ServiceManager : IServiceManager
{
    
    private readonly Lazy<ICerereService> _cerereService;
    private readonly Lazy<ILucrareService> _lucrareService;
    private readonly Lazy<IPersoanaService> _persoanaService;
    private readonly Lazy<ICerereStatusService> _cerereStatusService;
    private readonly IRepositoryManager _repositoryManager;

    public ServiceManager(IRepositoryManager repoManager)
    {

        _cerereService = new Lazy<ICerereService>(() => new CerereService(repoManager));
        _cerereStatusService = new Lazy<ICerereStatusService>(() => new CerereStatusService(repoManager));
        _lucrareService = new Lazy<ILucrareService>(() => new LucrareService(repoManager));
        _persoanaService = new Lazy<IPersoanaService>(() => new PersoanaService(repoManager));
        _repositoryManager = repoManager;
    }

    public ICerereService CerereService => _cerereService.Value;
    public IPersoanaService PersoanaService => _persoanaService.Value;
    public ILucrareService LucrareService => _lucrareService.Value;
    public ICerereStatusService CerereStatus => _cerereStatusService.Value;
    public IRepositoryManager RepositoryManager => _repositoryManager;

    public async Task SaveAsync() => await _repositoryManager.SaveAsync();

    public void DetachAll() => _repositoryManager.DetachAll();

}