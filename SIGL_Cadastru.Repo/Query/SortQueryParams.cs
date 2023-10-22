using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Query;

public enum SortDirection 
{
    Asc,
    Desc
}
public class SortQueryParams
{
    public string SortingColumn { get; set; } = "ValabilPanaLa";
    public SortDirection SortingDirection { get; set; } = SortDirection.Asc;
}
