using Contracts;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Contracts
{
    public interface IServiceManager
    {
        EventService EventService { get; }
        IFormFactory FormFactory { get; }
        ICerereService CerereService { get; }
        IPersoanaService PersoanaService { get; }
        ICerereStatusService CerereStatus { get; }
        IRepositoryManager RepositoryManager { get; }
        Task SaveAsync();
        void DetachAll();
    }
}
