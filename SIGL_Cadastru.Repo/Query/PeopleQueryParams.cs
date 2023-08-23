using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.Query
{
    public class PeopleQueryParams
    {
        public string Search { get; set; } = string.Empty;
        public Role? Rol { get; set; } = null;

        public PeopleQueryParams() { }

        public PeopleQueryParams(string search, Role? rol)
        {
            Search = search;
            Rol = rol;
        }
    }
}
