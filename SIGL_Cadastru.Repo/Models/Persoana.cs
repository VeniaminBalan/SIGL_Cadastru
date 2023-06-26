using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGL_Cadastru.Repo.Models
{
    public enum Role
    {
        Client,
        Executant,
        Responsabil
    }
    public class Persoana
    {
        public Guid Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string IDNP { get; set; }
        public DateOnly DataNasterii { get; set; }
        public string Domiciliu { get; set; }
        public Role Rol { get; set; }
    }
}
