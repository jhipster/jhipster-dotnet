namespace BlazorWebClient.Services.GithubAction;

public class GithubActionService : AbstractEntityService, IGithubActionService
{
    public GithubActionService(HttpClient httpClient)
    : base(httpClient, "https://localhost:7107/api/projects/CI/GithubAction")
    {
    }
}
