using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Application.Services;

public class BlazorApplicationService : IBlazorApplicationService
{
    private readonly IBlazorDomainService _blazorDomainService;

    private readonly ILogger<BlazorApplicationService> _logger;

    public BlazorApplicationService(IBlazorDomainService blazorDomainService, ILogger<BlazorApplicationService> logger)
    {
        _blazorDomainService = blazorDomainService;
        _logger = logger;
    }
    public async Task Init(Project project)
    {
        await _blazorDomainService.Init(project);
    }
}
