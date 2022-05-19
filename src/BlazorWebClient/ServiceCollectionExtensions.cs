using BlazorWebClient.Services;
using BlazorWebClient.Services.Api;
using BlazorWebClient.Services.GithubAction;
using BlazorWebClient.Services.Init;
using BlazorWebClient.Services.Interfaces;
using BlazorWebClient.Services.Sonar;

namespace BlazorWebClient;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJHipsterLiteServices(this IServiceCollection service)
    {
        return service.AddScoped<IInitService, InitService>()
               .AddScoped<IApiService, ApiService>()
               .AddScoped<IGithubActionService, GithubActionService>()
               .AddScoped<ISonarService, SonarService>()
               .AddScoped<IBlazorService, BlazorService>();
    }
}
