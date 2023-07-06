using Contracts;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;

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
        throw new NotImplementedException();
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
