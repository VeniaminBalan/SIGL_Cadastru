

namespace SIGL_Cadastru.App.Entities
{
    public class PersoanaDto
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string IDNP { get; set; }
        public DateOnly DataNasterii { get; set; }
        public string Domiciliu { get; set; }
    }
}
