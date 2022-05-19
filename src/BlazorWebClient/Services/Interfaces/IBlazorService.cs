using JHipster.NetLite.Domain.Entities;

namespace BlazorWebClient.Services.Interfaces;

public interface IBlazorService
{
    Task Post(Project project);
}
