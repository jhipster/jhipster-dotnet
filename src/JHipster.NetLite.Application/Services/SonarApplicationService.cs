// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Application.Services;

public class SonarApplicationService : ISonarApplicationService
{
    private readonly ISonarDomainService _sonarDomainService;

    private readonly ILogger<SonarApplicationService> _logger;

    public SonarApplicationService(ISonarDomainService sonarDomainService, ILogger<SonarApplicationService> logger)
    {
        _sonarDomainService = sonarDomainService;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await _sonarDomainService.Init(project);
    }
}
