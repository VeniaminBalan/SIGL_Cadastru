using Models;
using SIGL_Cadastru.Repo.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGL_Cadastru.Repo.Models
{

    public enum Status
    {
        Inlucru,
        LaReceptie,
        Eliberat,
        Respins
    }
    public class Cerere : IModel
    {
        [Column("CerereId")]
        public Guid Id { get; set; }

        [ForeignKey("ClientId")]
        public Guid ClientId { get; set; }
        public Persoana Client { get; set; }

        [ForeignKey("ExecutantId")]
        public Guid ExecutantId { get; set; }
        public Persoana Executant { get; set; }

        [ForeignKey("ResponsabilId")]
        public Guid ResponsabilId { get; set; }
        public Persoana Responsabil { get; set; }

        public DateOnly ValabilDeLa { get; set; }
        public DateOnly ValabilPanaLa { get; set; }
        public List<Lucrare> Lucrari { get; set; }
        public string NrCadastral { get; set; }
        public int CostTotal { get; set; } // <-- Remove
        //public int Ados {get;set;} <-- add
        public List<CerereStatus> StatusList { get; set; }

        //public string Comment {get;set;} <-- add
        
    }

}
