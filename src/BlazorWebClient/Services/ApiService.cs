using BlazorWebClient.Services.Interfaces;

namespace BlazorWebClient.Services
{
    public class ApiService : AbstractEntityService, IApiService
    {
        public ApiService(HttpClient httpClient)
            : base(httpClient, "https://localhost:7107/api/projects/api")
        {
        }
    }
}
