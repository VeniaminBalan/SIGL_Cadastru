using SIGL_Cadastru.Repo.Contracts;


namespace SIGL_Cadastru.Repo.Models
{
    public class Lucrare : IModel
    {
        public Guid Id {get;set; }
        public Cerere Cerere { get; set; }
        public Guid CerereId { get; private set; }
        public string TipLucrare { get; set; }
        public int Pret { get; set; }
    }
}
