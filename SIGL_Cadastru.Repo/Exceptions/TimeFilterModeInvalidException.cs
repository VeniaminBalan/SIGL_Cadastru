using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions;

public  class TimeFilterModeInvalidException : Exception
{
    public TimeFilterModeInvalidException(string message) : base(message) 
    {

    }
}
