namespace JHipster.NetLite.Infrastructure.Repositories.Exceptions;

public class InvalidFolderException : Exception
{
    public InvalidFolderException() : base() { }
    public InvalidFolderException(string message) : base(message) { }
    public InvalidFolderException(string message, Exception innerException) : base(message, innerException) { }


}
