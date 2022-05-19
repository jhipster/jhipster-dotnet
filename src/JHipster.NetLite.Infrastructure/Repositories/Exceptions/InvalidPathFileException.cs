
namespace JHipster.NetLite.Infrastucture.Repositories.Exceptions;

public class InvalidPathFileException : Exception
{
    public InvalidPathFileException() : base() { }
    public InvalidPathFileException(string message) : base(message) { }
    public InvalidPathFileException(string message, Exception innerException) : base(message, innerException) { }
}
