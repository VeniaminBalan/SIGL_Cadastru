using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers;

public static class LucrareMapper
{
    public static LucrareDto Map(Lucrare lucrare) 
    {
        return new LucrareDto 
        {
            Pret = lucrare.Pret,
            TipLucrare = lucrare.TipLucrare
        };
    }
}
