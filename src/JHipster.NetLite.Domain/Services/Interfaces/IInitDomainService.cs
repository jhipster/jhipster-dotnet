using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface IInitDomainService
{
    Task Init(Project project);
}
