namespace JHipster.NetLite.Infrastructure.Repositories.Exceptions;

public class InvalidPathFileException : Exception
{
    public InvalidPathFileException() : base() { }
    public InvalidPathFileException(string message) : base(message) { }
    public InvalidPathFileException(string message, Exception innerException) : base(message, innerException) { }
}
