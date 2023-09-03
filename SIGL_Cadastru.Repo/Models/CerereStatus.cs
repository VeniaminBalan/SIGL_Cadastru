
using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class CerereStatus : IModel
{
    public Guid Id { get; set; }
    public Cerere Cerere { get; set; }
    public Guid CerereId { get; private set; }
    public Status Starea { get; set; }
    public DateOnly Created { get; set; }

}
