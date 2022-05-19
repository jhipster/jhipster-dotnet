using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services.Sonar;

public class SonarService : AbstractEntityService, ISonarService
{
    public SonarService(HttpClient httpClient, IMapper mapper)
    : base(httpClient, mapper, "https://localhost:7107/api/projects/sonar")
    {
    }
}
