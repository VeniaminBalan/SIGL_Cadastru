﻿using AutoMapper;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cerere, CerereDto>()
            .ForMember(c => c.Client, opt => opt.MapFrom(x => string.Join(' ', x.Client.Nume, x.Client.Prenume)))
            .ForMember(c => c.Executant, opt => opt.MapFrom(x => string.Join(' ', x.Executant.Nume, x.Executant.Prenume)))
            .ForMember(c => c.Responsabil, opt => opt.MapFrom(x => string.Join(' ', x.Responsabil.Nume, x.Responsabil.Prenume)));
        //.ForMember(c => c.StareaCererii, opt => opt.MapFrom(x=>  ));

        CreateMap<Persoana, PersoanaDto>();
    }
}
