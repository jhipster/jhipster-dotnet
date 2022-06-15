using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IInitApplicationService
{
    Task InitAsync(Project project);
}

