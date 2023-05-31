using SIGL_Cadastru.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.AppConfigurations
{
    public interface IFormFactory
    {
        public FormCerere CreateCerere();
        public FormMain CreateMain();

    }
}
