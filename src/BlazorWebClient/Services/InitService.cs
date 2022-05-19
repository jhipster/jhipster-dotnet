using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services.Init;

public class InitService : AbstractEntityService, IInitService
{
    public InitService(HttpClient httpClient, IMapper mapper)
    : base(httpClient, mapper, "https://localhost:7107/api/projects/init")
    {
    }
}
