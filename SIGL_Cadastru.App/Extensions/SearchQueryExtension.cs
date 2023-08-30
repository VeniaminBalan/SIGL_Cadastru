using Exceptions;
using Query;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;

namespace Extensions;

public static class SearchQueryExtension
{
    public static IEnumerable<CerereDto> SearchBy(this IEnumerable<CerereDto> list, SearchQuery query)
    {
        if (string.IsNullOrWhiteSpace(query.Search))
            return list;

        var column = query.SearchColumn
            .Trim()
            .ToLower();

        var search = query.Search.ToLower();

        switch (column)
        {
            case "nr cadastral":
                return list.Where(c => c.NrCadastral.Contains(query.Search));

            case "client":
                return list.Where(c => c.Client.ToLower().Contains(search));

            case "responsabil":
                return list.Where(c => c.Responsabil.ToLower().Contains(search));

            case "executant":
                return list.Where(c => c.Executant.ToLower().Contains(search));

            default:
                throw new SearchColumnInvalidException($"{column} column does not exist");
        }
    }
}
