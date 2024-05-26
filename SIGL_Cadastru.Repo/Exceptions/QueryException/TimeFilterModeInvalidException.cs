using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Exceptions.QueryException;

public class TimeFilterModeInvalidException : Exception
{
    public TimeFilterModeInvalidException(string message) : base(message)
    {

    }
}
