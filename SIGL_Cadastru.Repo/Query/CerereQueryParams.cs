using SIGL_Cadastru.Repo.Models;
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
