using AutoMapper;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JHipster.NetLite.Core.Controllers.Projects;

[ApiController]
[Route("[controller]")]
public class InitController : ControllerBase
{
    private readonly ILogger<InitController> _logger;

    private readonly IInitApplicationService _initApplicationService;

    private readonly IMapper _mapper;

    public InitController(ILogger<InitController> logger, IInitApplicationService initApplicationService, IMapper mapper)
    {
        _logger = logger;
        _initApplicationService = initApplicationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Generating the Readme file, initializes the project solution and Git
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
    ///        "sslPort": "12345",
    ///        "GitName": "Jean.Dupont",
    ///        "GitEmail": "jean.dupont@gmail.com"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    [Route("/api/projects/init")]
    public async Task<IActionResult> PostAsync(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _initApplicationService.InitAsync(project);

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
