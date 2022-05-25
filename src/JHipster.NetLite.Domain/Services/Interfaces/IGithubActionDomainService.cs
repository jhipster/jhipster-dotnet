using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface IGithubActionDomainService
{
    Task Init(Project project);
}
