using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SIGL_Cadastru.Repo.Models
{

    public enum Status
    {
        Inlucru,
        LaReceptie,
        Eliberat,
        Respins
    }
    public class Cerere
    {
        [Column("CerereId")]
        public Guid Id { get; set; }


        [ForeignKey(nameof(Persoana))]
        public Guid ClientId { get; set; }
        public Persoana Client { get; set; }


        [ForeignKey(nameof(Persoana))]
        public Guid ExecutantId { get; set; }
        public Persoana Executant { get; set; }


        [ForeignKey(nameof(Persoana))]
        public Guid ResponsabilId { get; set; }
        public Persoana Responsabil { get; set; }

        IList<Lucrare> Lucrari { get; set; }
        public string NrCadastral { get; set; }
        public DateOnly ValabilDeLa { get; set; }
        public DateOnly ValabilPanaLa { get; set; }
        public DateOnly? Prelungit { get; set; }
        public int CostTotal { get; set; }
        public Status? StareaCererii { get; set; }
        public DateOnly? LaReceptie { get; set; }
        public DateOnly? Eliberat { get; set; }
        public DateOnly? Respins { get; set; }
    }
}
