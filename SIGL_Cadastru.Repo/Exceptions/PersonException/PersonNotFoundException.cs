namespace SIGL_Cadastru.Repo.Exceptions.PersonException;

public class PersonNotFoundException : Exception
{
    public PersonNotFoundException(string message) : base(message)
    { }
}
