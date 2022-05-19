using JHipster.NetLite.Domain.Entities;

namespace BlazorWebClient.Services.Sonar;

public interface ISonarService
{
    Task Post(Project project);
}
