using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class CerereStatus
{
    public Guid Id { get; set; }
    public Status Starea { get; set; }
    public DateOnly Created { get; set; }
    [ForeignKey("CerereId")]
    public Guid CerereId { get; set; }
    public Cerere Cerere { get; set; }

    private CerereStatus() 
    {
        Id = Guid.NewGuid();
    }

    public static CerereStatus NewStatusInLucru(Cerere cerere) 
    {
        return new CerereStatus 
        {
            Starea = Status.Inlucru,
            Created = DateOnly.FromDateTime(DateTime.Now),
            Cerere= cerere
        };
    }

    public static CerereStatus NewStatusEliberat(Cerere cerere, DateOnly date)
    {
        return new CerereStatus
        {
            Starea = Status.Eliberat,
            Created = date,
            Cerere = cerere
        };
    }
}
