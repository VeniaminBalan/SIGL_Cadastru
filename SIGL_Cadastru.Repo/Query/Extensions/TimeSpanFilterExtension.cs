using Query;
using SIGL_Cadastru.Repo.Exceptions.QueryException;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.Query.Extensions;

internal static class TimeSpanFilterExtension
{
    public static IEnumerable<Cerere> FilterBy(this IEnumerable<Cerere> list, TimeSpanFilter timeSpanFilter)
    {

        switch (timeSpanFilter.FilterMode)
        {
            case TimeFilterMode.Mixt:
                return list.Where(c =>
                {
                    var prelunigt = c.StatusList
                    .OrderByDescending(s => s.Created)
                    .FirstOrDefault(s => s.Starea == Status.Prelungit);

                    if (prelunigt is not null && prelunigt.Created >= c.ValabilPanaLa)
                        return c.ValabilDeLa >= timeSpanFilter.StartTime && prelunigt.Created <= timeSpanFilter.EndTime;

                    return c.ValabilDeLa >= timeSpanFilter.StartTime && c.ValabilPanaLa <= timeSpanFilter.EndTime;
                });

            case TimeFilterMode.StartDate:
                return list.Where(c => c.ValabilDeLa >= timeSpanFilter.StartTime);

            case TimeFilterMode.EndDate:
                return list.Where(c => c.ValabilPanaLa <= timeSpanFilter.EndTime);

            default:
                throw new TimeFilterModeInvalidException("Filter mode invalid");
        }
    }
}
