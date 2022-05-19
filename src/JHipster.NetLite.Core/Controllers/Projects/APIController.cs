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

namespace JHipster.NetLite.Web.Controllers.Projects;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;

    private readonly IApiApplicationService _apiApplicationService;

    private readonly IMapper _mapper;

    public ApiController(ILogger<ApiController> logger, IApiApplicationService apiApplicationService, IMapper mapper)
    {
        _logger = logger;
        _apiApplicationService = apiApplicationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Generating the web api project
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
    [Route("/api/projects/api")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _apiApplicationService.Init(project);

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
