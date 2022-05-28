using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class GithubActionDomainService : IGithubActionDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<GithubActionDomainService> _logger;

    public GithubActionDomainService(IProjectRepository projectRepository, ILogger<GithubActionDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task InitAsync(Project project)
    {
        await AddGithubActionAsync(project);
    }

    private async Task AddGithubActionAsync(Project project)
    {
        //Dotnet yml
        await _projectRepository.AddAsync(project.Folder, Path.Join("GithubAction", ".github", "workflows"), "dotnet.yml");
    }
}
