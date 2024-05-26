using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Exceptions.QueryException;

public class SearchColumnInvalidException : Exception
{
    public SearchColumnInvalidException(string message) : base(message)
    {

    }
}
