namespace JHipster.NetLite.Infrastructure.Repositories.Exceptions;

public class ExecutableNotFoundException : Exception
{
    public ExecutableNotFoundException() : base() { }
    public ExecutableNotFoundException(string message) : base(message) { }
    public ExecutableNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
