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

    public async Task Init(Project project)
    {
        await CreateAPI(project);
    }

    private async Task CreateAPI(Project project)
    {
        //Web Api
        await _projectRepository.Template(project, Path.Join("Api", "WebApi"), "WeatherForecast.cs");
        await _projectRepository.Template(project, Path.Join("Api", "WebApi"), "Program.cs");
        await _projectRepository.Template(project, Path.Join("Api", "WebApi"), "appsettings.json");
        await _projectRepository.Template(project, Path.Join("Api", "WebApi"), "appsettings.Development.json");
        await _projectRepository.Template(project, Path.Join("Api", "WebApi", "Properties"), "launchSettings.json");
        await _projectRepository.Template(project, Path.Join("Api", "WebApi", "Controllers"), "WeatherForecastController.cs");
        //Editorconfig
        await _projectRepository.Add(project.Folder, Path.Join("Api", "WebApi"), ".editorconfig");
    }
}
