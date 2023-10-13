using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;



namespace SIGL_Cadastru.App.Services;
public class PdfGeneratorService : IPdfGeneratorService
{
    private readonly string _path;

    public PdfGeneratorService(string path)
    {
        _path = path;
    }

    public string GeneratePdf(Cerere cerere)
    {
        var filename = "\\test.pdf";

        var doc = PdfHelper.PdfHelper.Create(cerere);
        doc.SaveToFile(_path + filename);

        return _path + filename;
    }

}
