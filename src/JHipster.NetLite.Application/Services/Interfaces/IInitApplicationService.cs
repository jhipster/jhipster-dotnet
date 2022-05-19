using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IInitApplicationService
{
    Task Init(Project project);
}

