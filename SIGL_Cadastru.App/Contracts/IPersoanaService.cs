using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;


namespace SIGL_Cadastru.App.Contracts;

public interface IPersoanaService
{
    Task<IEnumerable<PersoanaDto>> GetAllAync(PeopleQueryParams queryParams,bool trackChanges);
    Task<PersoanaDto> GetByIdAsync(Guid Id, bool trackChanges);
    void CreatePersoana(Persoana perosana);
    void DeletePersoana(Persoana perosana);
}
