using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Contracts
{
    public interface IServiceManager
    {
        ICerereService CerereService { get; }
        IPersoanaService PersoanaService { get; }
        ILucrareService LucrareService { get; }
        ICerereStatusService CerereStatus { get; }
        IRepositoryManager RepositoryManager { get; }
        Task SaveAsync();
    }
}
