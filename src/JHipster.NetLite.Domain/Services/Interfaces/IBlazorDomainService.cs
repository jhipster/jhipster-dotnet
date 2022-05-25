using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface IBlazorDomainService
{
    Task Init(Project project);
}
