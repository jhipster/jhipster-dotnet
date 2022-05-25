namespace BlazorWebClient.Services.Sonar;

public class SonarService : AbstractEntityService, ISonarService
{
    public SonarService(HttpClient httpClient)
    : base(httpClient, "https://localhost:7107/api/projects/sonar")
    {
    }
}
