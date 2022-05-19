// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services;

public class BlazorDomainService : IBlazorDomainService
{
    private readonly IProjectRepository _projectRepository;

    private readonly ILogger<BlazorDomainService> _logger;

    private const string CsprojName = "BlazorGeneration";

    public BlazorDomainService(IProjectRepository projectRepository, ILogger<BlazorDomainService> logger)
    {
        _projectRepository = projectRepository;
        _logger = logger;
    }

    public async Task Init(Project project)
    {
        await CreateBlazorWebClient(project);
    }

    private async Task CreateBlazorWebClient(Project project)
    {
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Model"), "WeatherForecast.cs");

        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Pages"), "Counter.razor");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Pages"), "FetchData.razor");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Pages"), "Index.razor");

        await _projectRepository.Template(project, Path.Join("Blazor", "BlazorWebClient", "Properties"), "launchSettings.json");

        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Shared"), "MainLayout.razor");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Shared"), "MainLayout.razor.css");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Shared"), "NavMenu.razor");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Shared"), "NavMenu.razor.css");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "Shared"), "SurveyPrompt.razor");

        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "bootstrap"), "bootstrap.min.css");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic", "font", "css"), "open-iconic-bootstrap.min.css");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic", "font", "fonts"), "open-iconic.eot");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic", "font", "fonts"), "open-iconic.otf");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic", "font", "fonts"), "open-iconic.svg");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic", "font", "fonts"), "open-iconic.ttf");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic"), "FONT-LICENSE");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic"), "ICON-LICENSE");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css", "open-iconic"), "README.md");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "css"), "app.css");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot", "sample-data"), "weather.json");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot"), "favicon.ico");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot"), "icon-192.png");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient", "wwwroot"), "index.html");

        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient"), "_Imports.razor");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient"), "App.razor");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient"), CsprojName + ".csproj");
        await _projectRepository.Add(project.Folder, Path.Join("Blazor", "BlazorWebClient"), "Program.cs");

        _projectRepository.AddProjectsToSolution(project, project.ProjectName, Path.Join("BlazorWebClient", CsprojName));
    }
}
