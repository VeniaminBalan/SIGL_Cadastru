using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;
using SIGL_Cadastru.Repo.Query.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query;

public enum FilterMode 
{   
    
}

public class CerereQueryParams
{
    public SearchQuery? Search { get; set; } = null;
    public TimeSpanFilter? TimeFilter { get; set; } = null;
    public StateFilter? StateFilter { get; set; } = null;
    public SortQueryParams SortParams { get; set; } = new();

    public CerereQueryParams()
    {
    }
    public CerereQueryParams(SearchQuery? search, TimeSpanFilter? timeFilter)
    {
        Search = search;
        TimeFilter = timeFilter;
    }
    public CerereQueryParams(SearchQuery? search, TimeSpanFilter? timeFilter, StateFilter stateFilter) : this(search, timeFilter)
    {
        StateFilter = stateFilter;
    }
}
