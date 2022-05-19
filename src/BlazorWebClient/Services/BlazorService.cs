using AutoMapper;
using BlazorWebClient.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services;

public class BlazorService : AbstractEntityService, IBlazorService
{
    public BlazorService(HttpClient httpClient, IMapper mapper)
    : base(httpClient, mapper, "https://localhost:7107/api/projects/clients/Blazor")
    {
    }
}
