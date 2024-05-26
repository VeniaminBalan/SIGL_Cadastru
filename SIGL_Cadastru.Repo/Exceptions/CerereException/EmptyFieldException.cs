
namespace SIGL_Cadastru.Repo.Exceptions.CerereException;

public class EmptyFieldException : Exception
{
    public string Field { get; init; }
    public EmptyFieldException(string field, string message) : base(message)
    {
        Field = field;
    }

}
