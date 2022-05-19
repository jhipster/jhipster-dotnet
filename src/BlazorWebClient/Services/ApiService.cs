using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services.Api;

public class ApiService : AbstractEntityService, IApiService
{
    public ApiService(HttpClient httpClient, IMapper mapper)
        : base(httpClient, mapper, "https://localhost:7107/api/projects/api")
    {
    }
}
