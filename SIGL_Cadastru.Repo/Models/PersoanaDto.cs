

namespace SIGL_Cadastru.Repo.Models
{
    public enum Role 
    {
        Client,
        Executant,
        Responsabil
    }
    public class PersoanaDto : Model
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string IDNP { get; set; }
        public DateOnly DataNasterii { get; set; }
        public string Domiciliu { get; set; }
        public Role Rol { get; set; }
    }
}
