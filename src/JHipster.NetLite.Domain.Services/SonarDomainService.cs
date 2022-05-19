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

    public async Task Init(Project project)
    {
        await AddSonar(project);
    }

    private async Task AddSonar(Project project)
    {
        await _projectRepository.Add(project.Folder, "Sonar", "SonarQube.Analysis.xml");
    }
}
