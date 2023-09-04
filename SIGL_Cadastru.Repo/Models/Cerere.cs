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
        public Guid Id { get;private set; }

        public Guid ClientId { get; private set; }
        public Persoana Client { get; private set; }

        public Guid ExecutantId { get; private set; }
        public Persoana Executant { get; private set; }

        public Guid ResponsabilId { get; private set; }
        public Persoana Responsabil { get; private set; }
        public DateOnly ValabilDeLa { get; private set; }
        public DateOnly ValabilPanaLa { get; private set; }

        public string NrCadastral { get; private set; }
        public int Adaos { get; private set; }
        public string Comment { get; private set; }


        private readonly List<Lucrare> _lucrari = new();
        private readonly List<CerereStatus> _stateList = new();

        public IReadOnlyList<Lucrare> Lucrari => _lucrari;
        public IReadOnlyList<CerereStatus> StatusList => _stateList;

        public Cerere(Guid id, Guid clientId, Persoana client, Guid executantId, Persoana executant, Guid responsabilId, Persoana responsabil, DateOnly valabilDeLa, DateOnly valabilPanaLa, string nrCadastral, int adaos, string comment, List<Lucrare> lucrari, List<CerereStatus> stateList)
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
            NrCadastral = nrCadastral;
            Adaos = adaos;
            Comment = comment;
            _lucrari = lucrari;
            _stateList = stateList;
        }

        private Cerere() { }


        public static Cerere Create(Guid id, Guid clientId, Persoana client, Guid executantId, Persoana executant, Guid responsabilId, Persoana responsabil, DateOnly valabilDeLa, DateOnly valabilPanaLa, string nrCadastral, int adaos, string comment, List<Lucrare> lucrari, List<CerereStatus> stateList) 
        {
            int costTotal = adaos;

            foreach (var item in lucrari)
            {
                costTotal += item.Pret;
            }

            if (costTotal < 0)
                throw new Exception("Costul total nu poate fi mai mic de 0");

            return new Cerere(id,clientId, client,executantId, executant,responsabilId, responsabil, valabilDeLa, valabilPanaLa, nrCadastral, adaos, comment, lucrari, stateList);

        }

        public void AddStatus(CerereStatus cerereStatus) 
        {
            if (cerereStatus.Created < this.ValabilDeLa)
                throw new Exception($"data starii ({cerereStatus.Created}) nu poate fi mai devreme de data de cand e valabila cererea");

            _stateList.Add(cerereStatus);
        }
        public void AddLucrare(Lucrare lucrare) 
        {
            _lucrari.Add(lucrare);
        }

        public void SetComment(string _comment) 
        {
            this.Comment = _comment;
        }
    }

}
