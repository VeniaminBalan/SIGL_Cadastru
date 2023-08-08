using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Entities.DataTransferObjects
{
    public class CerereStatusDto
    {
        public Guid Id { get; set; }
        public Status Starea { get; set; }
        public DateOnly Created { get; set; }
    }
}
