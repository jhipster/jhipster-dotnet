
namespace JHipster.NetLite.Infrastucture.Repositories.Exceptions;

public class InvalidNewPathFileException : Exception
{
    public InvalidNewPathFileException() : base() { }
    public InvalidNewPathFileException(string message) : base(message) { }
    public InvalidNewPathFileException(string message, Exception innerException) : base(message, innerException) { }
}
