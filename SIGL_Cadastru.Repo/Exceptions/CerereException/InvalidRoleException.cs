using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Repo.Exceptions.CerereException;

public class InvalidRoleException : Exception
{
    Persoana Person { get; init; }
    Role Role { get; init; }
    public InvalidRoleException(Role role, Persoana persoana) : base($"persoana cu idnp: {persoana.IDNP} cu are drept de: {role}")
    {
        Person = persoana;
        Role = role;
    }

}