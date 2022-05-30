using BlazorWebClient.Services.Interfaces;

namespace BlazorWebClient.Services;

public class BlazorService : AbstractEntityService, IBlazorService
{
    public BlazorService(HttpClient httpClient)
    : base(httpClient, "https://localhost:7107/api/projects/clients/Blazor")
    {
    }
}
