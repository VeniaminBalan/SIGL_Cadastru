using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class CerereStatus
{
    public Guid Id { get; set; }
    public Status Starea { get; set; }
    public DateOnly Created { get; set; }
    public Cerere Cerere { get; set; }
}
