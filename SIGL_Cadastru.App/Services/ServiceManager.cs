using Contracts;
using SIGL_Cadastru.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repo;
        private readonly ILoggerManager _logger;

        public ServiceManager(IRepositoryManager repo, ILoggerManager logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public ICerereService CerereService => throw new NotImplementedException();

        public IPersoanaService PersoanaService => throw new NotImplementedException();

        public ILucrareService lucrareService => throw new NotImplementedException();
    }
}
