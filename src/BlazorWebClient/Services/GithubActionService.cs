using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services.GithubAction;

public class GithubActionService : AbstractEntityService, IGithubActionService
{
    public GithubActionService(HttpClient httpClient, IMapper mapper)
    : base(httpClient, mapper, "https://localhost:7107/api/projects/CI/GithubAction")
    {
    }
}
