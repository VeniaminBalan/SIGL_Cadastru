using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query;

public class CerereQueryParams
{
    public string Search { get; private set; } = string.Empty;
    public string NrCadastral { get; private set; } = string.Empty;
    public string Comment { get; private set; } = string.Empty;

    public DateOnly? StartTime { get; private set; } = null;
    public DateOnly? EndTime { get; private set; } = null;

    public CerereQueryParams() { }
    public CerereQueryParams(string search)
    {
        Search = search;
    }
    public CerereQueryParams(string search, string nrCadastral) : this(search)
    {
        NrCadastral = nrCadastral;
    }
    public CerereQueryParams(string search, string nrCadastral, string comment) : this(search, nrCadastral)
    {
        Comment = comment;
    }
    public CerereQueryParams(string search, string nrCadastral, string comment, DateOnly? startTime, DateOnly? endTime) : this(search, nrCadastral, comment)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
}
