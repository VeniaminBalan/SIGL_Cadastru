using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers;

public static class PersoanaMapper
{
    public static PersoanaDto Map(Persoana persoana) 
    {
        return new PersoanaDto
        {
            Id= persoana.Id,
            Nume= persoana.Nume,
            Prenume= persoana.Prenume,
            IDNP= persoana.IDNP,
            DataNasterii= persoana.DataNasterii,
            Domiciliu= persoana.Domiciliu,
            Email= persoana.Email,
            Telefon= persoana.Telefon,
        };
    }
}
