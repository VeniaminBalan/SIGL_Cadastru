using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.ValueObjects;


public class Portofoliu
{
    private List<Document> _documente = new();
    private readonly List<Lucrare> _lucrari = new();

    public IReadOnlyList<Document> Documente => _documente;
    public IReadOnlyList<Lucrare> Lucrari => _lucrari;

    public Portofoliu() { }

    public Portofoliu(List<Document> documente, List<Lucrare> lucrari)
    {
        _documente = documente;
        _lucrari = lucrari;
    }

    public void AddLucrare(Lucrare lucrare)
    {
        _lucrari.Add(lucrare);
    }

    public void AddDocument(Document doc)
    {
        _documente.Add(doc);
    }

    public void AddDocumentsSource(List<Document> documente)
    {
        _documente = documente;
    }
}
