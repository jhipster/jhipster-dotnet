namespace BlazorWebClient.Services.Init;

public class InitService : AbstractEntityService, IInitService
{
    public InitService(HttpClient httpClient)
    : base(httpClient, "https://localhost:7107/api/projects/init")
    {
    }
}
