﻿using Models;
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
            return new CerereDto
            {
                Id = cerere.Id,
                ResponsabilId = cerere.ResponsabilId,
                Responsabil = string.Join(' ', cerere.Responsabil.Nume, cerere.Responsabil.Prenume),

                ExecutantId = cerere.ExecutantId,
                Executant = string.Join(' ', cerere.Executant.Nume, cerere.Executant.Prenume),

                ClientId = cerere.ClientId,
                Client = string.Join(' ', cerere.Client.Nume, cerere.Client.Prenume),

                NrCadastral = cerere.NrCadastral,
                ValabilDeLa = cerere.ValabilDeLa,
                ValabilPanaLa = cerere.ValabilPanaLa,
                CostTotal= cerere.CostTotal,

                StareaCererii = SetStatus(cerere.StatusList),
                LaReceptie = GetDate(cerere.StatusList, Status.LaReceptie),
                Eliberat = GetDate(cerere.StatusList, Status.Eliberat),
                Respins = GetDate(cerere.StatusList, Status.Respins)
            };
        }

        private static Status SetStatus(List<CerereStatus> stari)
        {
            var state = stari.OrderByDescending(x => x.Created).First();
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
