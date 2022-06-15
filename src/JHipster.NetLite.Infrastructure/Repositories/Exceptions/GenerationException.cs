namespace JHipster.NetLite.Infrastructure.Repositories.Exceptions;

public class GenerationException : Exception
{
    public GenerationException() : base() { }
    public GenerationException(string message) : base(message) { }
    public GenerationException(string message, Exception innerException) : base(message, innerException) { }
}
