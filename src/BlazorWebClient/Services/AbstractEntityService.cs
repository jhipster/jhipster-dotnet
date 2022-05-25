using JHipster.NetLite.Dto;
using System.Net.Http.Json;

namespace BlazorWebClient.Services;

public class AbstractEntityService
{
    protected readonly HttpClient _httpClient;

    protected string BaseUrl { get; }

    public AbstractEntityService(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        BaseUrl = baseUrl;
    }

    public virtual async Task Post(ProjectDto projectDto)
    {
        await _httpClient.PostAsJsonAsync(BaseUrl, projectDto);
    }
}
