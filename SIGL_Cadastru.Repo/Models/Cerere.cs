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
        public Persoana Client { get; private set; }
        public Persoana Executant { get; private set; }
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


        private Cerere() { }

        public Cerere(Guid id, Persoana client, Persoana executant, Persoana responsabil, DateOnly valabilDeLa, DateOnly valabilPanaLa, string nrCadastral, int adaos, string comment, HashSet<Lucrare> lucrari, HashSet<CerereStatus> stateList)
        {
            Id = id;
            Client = client;
            Executant = executant;
            Responsabil = responsabil;
            ValabilDeLa = valabilDeLa;
            ValabilPanaLa = valabilPanaLa;
            NrCadastral = nrCadastral;
            Adaos = adaos;
            Comment = comment;
            _lucrari = lucrari.ToList();
            _stateList = stateList.ToList();
        }

        public static Cerere Create(Guid id, Persoana client, Persoana executant, Persoana responsabil, DateOnly valabilDeLa, DateOnly valabilPanaLa, HashSet<Lucrare> lucrari, string nrCadastral, int adaos, string comment, HashSet<CerereStatus> statusList) 
        {
            int costTotal = adaos;

            foreach (var item in lucrari)
            {
                costTotal += item.Pret;
            }

            if (costTotal < 0)
                throw new Exception("Costul total nu poate fi mai mic de 0");

            return new Cerere(id, client, executant, responsabil, valabilDeLa, valabilPanaLa, nrCadastral, adaos, comment, lucrari, statusList);

        }

        public void AddStatus(CerereStatus cerereStatus) 
        {
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
