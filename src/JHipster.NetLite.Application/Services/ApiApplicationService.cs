using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Application.Services;

public class ApiApplicationService : IApiApplicationService
{
    private readonly IApiDomainService _apiDomainService;

    private readonly ILogger<ApiApplicationService> _logger;

    public ApiApplicationService(IApiDomainService apiDomainService, ILogger<ApiApplicationService> logger)
    {
        _apiDomainService = apiDomainService;
        _logger = logger;
    }
    public async Task Init(Project project)
    {
        await _apiDomainService.Init(project);
    }
}
