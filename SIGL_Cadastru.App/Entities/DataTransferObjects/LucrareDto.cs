using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Entities
{
    public class LucrareDto
    {
        public Guid Id { get; set; }
        public string TipLucrare { get; set; }
        public int Pret { get; set; }
    }
}
