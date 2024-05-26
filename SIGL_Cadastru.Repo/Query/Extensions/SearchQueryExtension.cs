using Query;
using SIGL_Cadastru.Repo.Exceptions.QueryException;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.Query.Extensions;

public static class SearchQueryExtension
{
    public static IQueryable<Cerere> SearchBy(this IQueryable<Cerere> list, SearchQuery query)
    {
        if (string.IsNullOrWhiteSpace(query.Search))
            return list;

        var column = query.SearchColumn
            .Trim()
            .ToLower();

        var search = query.Search.ToLower();

        switch (column)
        {
            case "nr":
                return list.Where(c => c.Nr.ToLower().Contains(search));

            case "nr cadastral":
                return list.Where(c => c.NrCadastral.Contains(search));

            case "client":
                return list.Where(c => (c.Client.Nume+" "+c.Client.Prenume).ToLower().Contains(search));

            case "responsabil":
                return list.Where(c => (c.Responsabil.Nume+""+c.Responsabil.Prenume).ToLower().Contains(search));

            case "executant":
                return list.Where(c => (c.Executant.Nume+" "+c.Executant.Prenume).ToLower().Contains(search));

            case "comentariu":
                return list.Where(c => c.Comment.ToLower().Contains(search));

            default:
                throw new SearchColumnInvalidException($" {column} column does not exist");
        }
    }
}
