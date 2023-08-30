
using Query;
using SIGL_Cadastru.App.Entities;


namespace Extensions;

internal static class StateFilterExtension
{
    public static IEnumerable<CerereDto> FilterByState(this IEnumerable<CerereDto> list,  StateFilter filter) 
    {
        if (filter is null)
            return list;

        return list.Where(c => filter.states.Contains(c.StareaCererii));
    }
}
