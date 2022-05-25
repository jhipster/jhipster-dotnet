using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface ISonarDomainService
{
    Task Init(Project project);
}
