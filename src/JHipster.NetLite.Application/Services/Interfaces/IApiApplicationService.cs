using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IApiApplicationService
{
    Task InitAsync(Project project);
}
