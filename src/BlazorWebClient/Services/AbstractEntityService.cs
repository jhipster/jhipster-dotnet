using AutoMapper;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;

namespace BlazorWebClient.Services;

public class AbstractEntityService
{
    protected readonly HttpClient _httpClient;
    protected readonly IMapper _mapper;

    protected string BaseUrl { get; }

    public AbstractEntityService(HttpClient httpClient, IMapper mapper, string baseUrl)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        BaseUrl = baseUrl;
    }

    public virtual async Task Post(Project project)
    {
        var projectDto = _mapper.Map<ProjectDto>(project);
        await _httpClient.PostAsJsonAsync(BaseUrl, projectDto);
    }
}
