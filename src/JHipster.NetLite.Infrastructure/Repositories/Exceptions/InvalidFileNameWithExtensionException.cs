
namespace JHipster.NetLite.Infrastucture.Repositories.Exceptions;

public class InvalidFileNameWithExtensionException : Exception
{
    public InvalidFileNameWithExtensionException() : base() { }
    public InvalidFileNameWithExtensionException(string message) : base(message) { }
    public InvalidFileNameWithExtensionException(string message, Exception innerException) : base(message, innerException) { }
}
