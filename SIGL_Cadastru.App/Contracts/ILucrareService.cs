using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Contracts
{
    public interface ILucrareService
    {
        public void CreateLucrare(Lucrare lucrare);
        public void DeleteLucrare(Lucrare lucrare);
        public Task<IList<LucrareDto>> GetAllByIdAsync(Guid cerereId, bool trackChanges);
    }
}
