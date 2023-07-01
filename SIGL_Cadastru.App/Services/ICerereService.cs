using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public interface ICerereService
{
    public Task CreateNewCerere(Cerere cerere);
    public Task<IEnumerable<Cerere>> GetAll();
    public Task<Cerere> GetById(Guid Id);
}
