using Contracts;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Services;


namespace SIGL_Cadastru.App.Contracts;

public interface IServiceManager
{
    IFormFactory FormFactory { get; }
    ICerereService CerereService { get; }
    IPersoanaService PersoanaService { get; }
    ICerereStatusService CerereStatus { get; }
    IRepositoryManager RepositoryManager { get; }
    Task SaveAsync();
    void DetachAll();
}
