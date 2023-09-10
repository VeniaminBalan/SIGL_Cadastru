using Models;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.App.Mappers
{
    public static class CerereMapper
    {
        public static CerereDto Map(Cerere cerere) 
        {
            int costTotal = cerere.Adaos;

            foreach (var l in cerere.Lucrari) 
            {
                costTotal += l.Pret;
            }

            return new CerereDto
            {
                Id = cerere.Id,
                Responsabil = string.Join(' ', cerere.Responsabil.Nume, cerere.Responsabil.Prenume),

                Executant = string.Join(' ', cerere.Executant.Nume, cerere.Executant.Prenume),

                Client = string.Join(' ', cerere.Client.Nume, cerere.Client.Prenume),

                NrCadastral = cerere.NrCadastral,
                ValabilDeLa = cerere.ValabilDeLa,
                ValabilPanaLa = cerere.ValabilPanaLa,
                Comment = cerere.Comment,
                CostTotal = costTotal,
                Nr = cerere.Nr,

                StareaCererii = SetStatus(cerere.StatusList.ToList()),
                LaReceptie = GetDate(cerere.StatusList.ToList(), Status.LaReceptie),
                Eliberat = GetDate(cerere.StatusList.ToList(), Status.Eliberat),
                Respins = GetDate(cerere.StatusList.ToList(), Status.Respins),
                Prelungit = GetDate(cerere.StatusList.ToList(), Status.Prelungit)
            };
        }

        public static Status SetStatus(List<CerereStatus> stari)
        {
            var state = stari
                .Where(s => s.Starea != Status.Prelungit)
                .OrderByDescending(x => x.Created).FirstOrDefault();

            if(state is null) return Status.Inlucru;

            return state.Starea;
        }

        private static DateOnly? GetDate(List<CerereStatus> stari, Status status)
        {
            var state = stari.OrderByDescending(x => x.Created).FirstOrDefault(d => d.Starea == status);

            if (state is null)
                return null;

            return state.Created;
        }
    }
}
