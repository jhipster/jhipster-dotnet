using JHipster.NetLite.Dto;

namespace BlazorWebClient.Services.Interfaces
{
    public interface IApiService
    {
        Task Post(ProjectDto projectDto);
    }
}
