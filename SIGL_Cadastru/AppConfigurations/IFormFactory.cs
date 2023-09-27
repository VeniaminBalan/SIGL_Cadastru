using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Views;
using SIGL_Cadastru.Views.Setari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.AppConfigurations
{
    public interface IFormFactory
    {
        FormCerere CreateCerere();
        FormMain CreateMain();
        FormViewCerere CreateFromViewCerere(Guid Id);
        UC_Main CreateUC_Main();
        UC_PersoanaExistenta CreateUC_PersoanaExistenta();
        UC_PersoanaNoua CreateUC_PersoanaNoua(Role role);
        UC_EditPersoana CreateUC_PersoanaEdit(Persoana perosana);
        FormSetari CreateFormSetari();
    }
}
