namespace JHipster.NetLite.Infrastructure.Repositories.Exceptions;

public class InvalidNewPathNameException : Exception
{
    public InvalidNewPathNameException() : base() { }
    public InvalidNewPathNameException(string message) : base(message) { }
    public InvalidNewPathNameException(string message, Exception innerException) : base(message, innerException) { }
}
