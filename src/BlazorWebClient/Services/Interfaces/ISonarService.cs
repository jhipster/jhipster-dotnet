using JHipster.NetLite.Dto;

namespace BlazorWebClient.Services.Sonar;

public interface ISonarService
{
    Task Post(ProjectDto projectDto);
}
