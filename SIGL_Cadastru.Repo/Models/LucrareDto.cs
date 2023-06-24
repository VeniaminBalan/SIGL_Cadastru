using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public class LucrareDto : Model
    {
        public string TipLucrare { get; set; }
        public int Pret { get; set; }
    }
}
