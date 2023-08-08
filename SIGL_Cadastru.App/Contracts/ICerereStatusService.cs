using Models;
using SIGL_Cadastru.App.Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Contracts
{
    public interface ICerereStatusService
    {
        Task<List<CerereStatusDto>> GetByIdAsync(Guid cerereId, bool trackChanges);
        void CreateCerere(CerereStatus cerere);
        void DeleteCerere(CerereStatus cerere);
    }
}
