using SIGL_Cadastru.Repo.Models;

namespace Query;

public class StateFilter
{
    public HashSet<Status> states { get; private set; } = new HashSet<Status>();

}
