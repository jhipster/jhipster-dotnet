// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Application.Services;

public class GithubActionApplicationService : IGithubActionApplicationService
{
    private readonly IGithubActionDomainService _githubActionDomainService;

    private readonly ILogger<GithubActionApplicationService> _logger;

    public GithubActionApplicationService(IGithubActionDomainService githubActionDomainService, ILogger<GithubActionApplicationService> logger)
    {
        _githubActionDomainService = githubActionDomainService;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await _githubActionDomainService.Init(project);
    }
}
