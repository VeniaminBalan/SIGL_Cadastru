using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public interface IModel
    {
        string Id { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}
