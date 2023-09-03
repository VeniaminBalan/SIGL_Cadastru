
using SIGL_Cadastru.Repo.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public class Lucrare : IModel
    {
        public Guid Id {get;set; }
        public Cerere Cerere { get; set; }
        public Guid CerereId { get; private set; }
        public string TipLucrare { get; set; }
        public int Pret { get; set; }
    }
}
