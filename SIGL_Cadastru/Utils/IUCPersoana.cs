using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Utils
{
    public interface IUCPersoana
    {
        public Persoana GetPersoana();
        public void SetView();
        public void CloseView();
    }
}
