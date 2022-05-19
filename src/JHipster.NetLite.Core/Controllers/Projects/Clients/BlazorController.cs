using AutoMapper;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Controllers.Projects.Clients;

[ApiController]
[Route("[controller]")]
public class BlazorController : ControllerBase
{
    private readonly ILogger<BlazorController> _logger;

    private readonly IBlazorApplicationService _blazorApplicationService;

    private readonly IMapper _mapper;

    public BlazorController(ILogger<BlazorController> logger, IBlazorApplicationService blazorApplicationService, IMapper mapper)
    {
        _logger = logger;
        _blazorApplicationService = blazorApplicationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Generating the Blazor web client
    /// </summary>
    /// <param name="folder"></param>
    /// <returns></returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "folder": "C:/Sample",
    ///        "namespace": "sample",
    ///        "projectName": "SampleProject",
    ///        "sslPort": "12345",
    ///        "GitName": "Jean.Dupont",
    ///        "GitEmail": "jean.dupont@gmail.com"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    [Route("/api/projects/clients/Blazor")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _blazorApplicationService.Init(project);

            _logger.LogInformation("Request succes");
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception in the Post method");
            return BadRequest(ex.Message);
        }
    }
}
