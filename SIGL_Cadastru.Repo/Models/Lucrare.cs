using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public class Lucrare
    {
        public Guid Id {get;set; }

        [ForeignKey(nameof(Cerere))]
        public Guid CerereId { get; set; }
        public Cerere Cerere { get; set; }
        public string TipLucrare { get; set; }
        public int Pret { get; set; }
    }
}
