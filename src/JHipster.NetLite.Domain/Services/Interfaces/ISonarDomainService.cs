// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;

namespace JHipster.NetLite.Domain.Services.Interfaces;

public interface ISonarDomainService
{
    Task Init(Project project);
}
