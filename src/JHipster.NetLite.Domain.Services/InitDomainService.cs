using HandlebarsDotNet.Compiler;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace JHipster.NetLite.Domain.Services;

public class InitDomainService : IInitDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<InitDomainService> _logger;

    private const string CsprojNameWebApi = "WebApi";

    private const string CsprojNameTests = "SampleTests";

    public InitDomainService(IProjectRepository projectRepository, ILogger<InitDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task InitAsync(Project project)
    {
        await AddReadmeAsync(project);
        await InitSolutionAsync(project);
        await InitTestsAsync(project);
        InitGit(project);
    }

    private async Task AddReadmeAsync(Project project)
    {
        await _projectRepository.TemplateAsync(project, "Init", "Readme.md");
    }

    private async Task InitSolutionAsync(Project project)
    {
        //Solution
        _projectRepository.GenerateSolution(project, project.ProjectName);
        //csproj
        await _projectRepository.TemplateAsync(project, Path.Join("Api", "WebApi"), CsprojNameWebApi + ".csproj");
        _projectRepository.AddProjectsToSolution(project, project.ProjectName, Path.Join("WebApi", CsprojNameWebApi));
    }

    private void InitGit(Project project)
    {
        _projectRepository.InitGit(project);
    }

    private async Task InitTestsAsync(Project project)
    {
        await _projectRepository.TemplateAsync(project, Path.Join("Tests", "SampleTests"), CsprojNameTests + ".csproj");
        _projectRepository.AddProjectsToSolution(project, project.ProjectName, Path.Join("SampleTests", CsprojNameTests));

        await _projectRepository.AddAsync(project.Folder, Path.Join("Tests", "SampleTests"), "UnitTest1.cs");
    }
}
