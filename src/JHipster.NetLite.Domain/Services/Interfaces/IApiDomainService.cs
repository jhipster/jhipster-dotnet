﻿using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface IApiDomainService
{
    Task InitAsync(Project project);
}
