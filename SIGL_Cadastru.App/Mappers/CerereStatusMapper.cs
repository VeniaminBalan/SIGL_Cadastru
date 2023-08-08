using Models;
using SIGL_Cadastru.App.Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers;

public static class CerereStatusMapper
{
    public static CerereStatusDto Map(CerereStatus cerereStatus) 
    {
        return new CerereStatusDto 
        {
            Created= cerereStatus.Created,
            Starea= cerereStatus.Starea,
            Id= cerereStatus.Id,
        };
    }
}
