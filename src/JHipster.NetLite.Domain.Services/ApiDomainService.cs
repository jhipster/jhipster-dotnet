using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class ApiDomainService : IApiDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<ApiDomainService> _logger;

    public ApiDomainService(IProjectRepository projectRepository, ILogger<ApiDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task InitAsync(Project project)
    {
        await CreateAPIAsync(project);
    }

    private async Task CreateAPIAsync(Project project)
    {
        //Web Api
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi"), "WeatherForecast.cs");
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi"), "Program.cs");
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi"), "appsettings.json");
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi"), "appsettings.Development.json");
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi", "Properties"), "launchSettings.json");
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi", "Controllers"), "WeatherForecastController.cs");
        //Editorconfig
        await _projectRepository.AddAsync(project.Folder, Path.Join("Api", "WebApi"), ".editorconfig");
    }
}
