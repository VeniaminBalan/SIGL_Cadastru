using Contracts;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Services
{
    internal class LucrareService : ILucrareService
    {
        private readonly IRepositoryManager _repo;

        public LucrareService(IRepositoryManager repo)
        {
            _repo = repo;
        }

        public Task CreateNewLucrare(Cerere cerere)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cerere>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Cerere> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
