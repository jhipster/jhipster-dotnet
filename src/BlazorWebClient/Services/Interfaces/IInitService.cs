using JHipster.NetLite.Domain.Entities;

namespace BlazorWebClient.Services.Init;

public interface IInitService
{
    Task Post(Project project);
}
