using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.App.Contracts;

public interface IPdfGeneratorService
{
    public string GeneratePdf(Cerere cerere);

}
