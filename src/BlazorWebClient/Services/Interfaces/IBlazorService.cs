using JHipster.NetLite.Dto;

namespace BlazorWebClient.Services.Interfaces;

public interface IBlazorService
{
    Task Post(ProjectDto projectDto);
}
