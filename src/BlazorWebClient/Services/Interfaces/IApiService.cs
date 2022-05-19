using JHipster.NetLite.Domain.Entities;

namespace BlazorWebClient.Services.Api;

public interface IApiService
{
    Task Post(Project project);
}
