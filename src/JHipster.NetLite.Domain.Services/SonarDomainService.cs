// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Domain.Services;

public class SonarDomainService : ISonarDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<SonarDomainService> _logger;

    public SonarDomainService(IProjectRepository projectRepository, ILogger<SonarDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task InitAsync(Project project)
    {
        await AddSonarAsync(project);
    }

    private async Task AddSonarAsync(Project project)
    {
        await _projectRepository.AddAsync(project.Folder, "Sonar", "SonarQube.Analysis.xml");
    }
}
