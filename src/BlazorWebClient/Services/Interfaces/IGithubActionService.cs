using JHipster.NetLite.Dto;

namespace BlazorWebClient.Services.GithubAction;

public interface IGithubActionService
{
    Task Post(ProjectDto projectDto);
}
