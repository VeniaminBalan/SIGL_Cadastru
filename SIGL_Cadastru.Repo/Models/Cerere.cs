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
        Respins,
        Prelungit
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
        public List<Lucrare> Lucrari { get; set; } = new();
        public string NrCadastral { get; set; }
        public int Adaos { get; set; }
        public string Comment { get; set; }
        public List<CerereStatus> StatusList { get; set; } = new();


        private Cerere() { }
        internal Cerere(Guid id, Guid clientId, Persoana client, Guid executantId, Persoana executant, Guid responsabilId, Persoana responsabil, DateOnly valabilDeLa, DateOnly valabilPanaLa, List<Lucrare> lucrari, string nrCadastral, int adaos, string comment, List<CerereStatus> statusList)
        {
            Id = id;
            ClientId = clientId;
            Client = client;
            ExecutantId = executantId;
            Executant = executant;
            ResponsabilId = responsabilId;
            Responsabil = responsabil;
            ValabilDeLa = valabilDeLa;
            ValabilPanaLa = valabilPanaLa;
            Lucrari = lucrari;
            NrCadastral = nrCadastral;
            Adaos = adaos;
            Comment = comment;
            StatusList = statusList;
        }

        public static Cerere Create(Guid id, Guid clientId, Persoana client, Guid executantId, Persoana executant, Guid responsabilId, Persoana responsabil, DateOnly valabilDeLa, DateOnly valabilPanaLa, List<Lucrare> lucrari, string nrCadastral, int adaos, string comment, List<CerereStatus> statusList) 
        {
            int costTotal = adaos;

            foreach (var item in lucrari)
            {
                costTotal += item.Pret;
            }

            if (costTotal < 0)
                throw new Exception("Costul total nu poate fi mai mic de 0");


            return new Cerere(id, clientId, client, executantId, executant, responsabilId, responsabil, valabilDeLa, valabilPanaLa, lucrari, nrCadastral, adaos, comment, statusList);
        }


    }

}
