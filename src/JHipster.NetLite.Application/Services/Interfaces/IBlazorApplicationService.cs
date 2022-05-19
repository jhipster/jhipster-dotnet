using JHipster.NetLite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Application.Services.Interfaces;

public interface IBlazorApplicationService
{
    Task Init(Project project);
}
