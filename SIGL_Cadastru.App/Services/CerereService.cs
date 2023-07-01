using Contracts;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class CerereService : ICerereService
{
    private readonly IRepositoryManager _repo;

    public CerereService(IRepositoryManager repo)
    {
        _repo = repo;
    }

    public async Task CreateNewCerere(Cerere cerere)
    {
        
    }

    public async Task<IEnumerable<Cerere>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<Cerere> GetById(Guid Id)
    {
        throw new NotImplementedException();
    }
}
