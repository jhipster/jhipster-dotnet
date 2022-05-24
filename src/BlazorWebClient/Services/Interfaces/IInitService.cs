using JHipster.NetLite.Dto;

namespace BlazorWebClient.Services.Init;

public interface IInitService
{
    Task Post(ProjectDto projectDto);
}
