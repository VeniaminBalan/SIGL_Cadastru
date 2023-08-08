using Models;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface ICerereStatusRepository
{
    Task<List<CerereStatus>> GetByIdAsync(Guid cerereId, bool trackChanges);
    void CreateCerere(CerereStatus cerere);
    void DeleteCerere(CerereStatus cerere);
}
