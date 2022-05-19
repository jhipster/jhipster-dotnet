using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Application.Services;

public class InitApplicationService : IInitApplicationService
{
    private readonly IInitDomainService _initDomainService;

    private readonly ILogger<InitApplicationService> _logger;

    public InitApplicationService(IInitDomainService initDomainService, ILogger<InitApplicationService> logger)
    {
        _initDomainService = initDomainService;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await _initDomainService.Init(project);
    }
}
