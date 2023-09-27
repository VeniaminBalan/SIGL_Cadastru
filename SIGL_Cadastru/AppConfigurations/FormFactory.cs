using Microsoft.Extensions.DependencyInjection;
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
    public class FormFactory : IFormFactory
    {

        static IFormFactory _provider;

        public static void SetProvider(IFormFactory provider)
        {
            _provider = provider;
        }
        public FormCerere CreateCerere()
        {
            return _provider.CreateCerere();
        }

        public FormViewCerere CreateFromViewCerere(Guid Id)
        {
            return _provider.CreateFromViewCerere(Id);
        }

        public FormMain CreateMain()
        {
            return _provider.CreateMain();
        }

        public UC_Main CreateUC_Main()
        {
            return _provider.CreateUC_Main();
        }

        public UC_PersoanaExistenta CreateUC_PersoanaExistenta()
        {
            return _provider.CreateUC_PersoanaExistenta();
        }

        public UC_PersoanaNoua CreateUC_PersoanaNoua(Role role)
        {
            return _provider.CreateUC_PersoanaNoua(role);
        }
        public FormSetari CreateFormSetari() 
        {
            return _provider.CreateFormSetari();
        }

        public UC_EditPersoana CreateUC_PersoanaEdit(Persoana perosana)
        {
            return _provider.CreateUC_PersoanaEdit(perosana);
        }
    }
}
