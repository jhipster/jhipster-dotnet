using AutoMapper;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Core.Controllers.Projects;

[ApiController]
[Route("[controller]")]
public class SonarController : ControllerBase
{
    private readonly ILogger<SonarController> _logger;

    private readonly ISonarApplicationService _sonarApplicationService;

    private readonly IMapper _mapper;

    public SonarController(ILogger<SonarController> logger, ISonarApplicationService sonarApplicationService, IMapper mapper)
    {
        _logger = logger;
        _sonarApplicationService = sonarApplicationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Generating the Sonar's files
    /// </summary>
    /// <param name="projectDto"></param>
    /// <returns></returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     {
    ///        "folder": "C:/Sample",
    ///        "namespace": "sample",
    ///        "projectName": "SampleProject",
    ///        "sslPort": "12345"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    [Route("/api/projects/sonar")]
    public async Task<IActionResult> PostAsync(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _sonarApplicationService.InitAsync(project);

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
