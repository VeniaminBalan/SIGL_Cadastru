using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Views.Adaugare_Lucrare;

internal interface ILucrareaAddView : IUserControl
{
    Lucrare GetLucrare();
}
