using JHipster.NetLite.Domain.Entities;

namespace BlazorWebClient.Services.GithubAction;

public interface IGithubActionService
{
    Task Post(Project project);
}
