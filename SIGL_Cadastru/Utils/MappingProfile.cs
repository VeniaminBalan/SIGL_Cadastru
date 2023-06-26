using AutoMapper;
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
        CreateMap<Cerere, CerereDto>();
    }
}
