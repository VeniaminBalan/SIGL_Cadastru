using Models;
using Query;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.Query.Extensions;

internal static class StateFilterExtension
{
    public static IQueryable<Cerere> FilterByState(this IQueryable<Cerere> list, StateFilter filter)
    {
        if (filter is null || filter.states.Count() == 4)
            return list;


        return list.Where(c => filter.states.Contains(
            c.StatusList
            .OrderByDescending(s => s.Created).First().Starea));
    }
}
