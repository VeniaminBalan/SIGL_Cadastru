using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Query;

public class SearchQuery
{
    public string Search { get; private set; } = string.Empty;
    public string SearchColumn { get; private set; }

    private SearchQuery(string search, string searchColumn)
    {
        Search = search;
        SearchColumn = searchColumn;
    }

    public static SearchQuery? Create(string search, string searchColumn) 
    {
        //if (string.IsNullOrEmpty(search))
        //    return null;

        if(string.IsNullOrEmpty(searchColumn))
            return null;

        return new SearchQuery(search, searchColumn);
    }
}
