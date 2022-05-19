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
public class GithubActionController : ControllerBase
{
    private readonly ILogger<GithubActionController> _logger;

    private readonly IGithubActionApplicationService _initApplicationGithubAction;

    private readonly IMapper _mapper;

    public GithubActionController(ILogger<GithubActionController> logger, IGithubActionApplicationService initApplicationGithubAction, IMapper mapper)
    {
        _logger = logger;
        _initApplicationGithubAction = initApplicationGithubAction;
        _mapper = mapper;
    }

    /// <summary>
    /// Generating the github action's files
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
    [Route("/api/projects/CI/GithubAction")]
    public async Task<IActionResult> Post(ProjectDto projectDto)
    {
        try
        {
            var project = _mapper.Map<Project>(projectDto);
            await _initApplicationGithubAction.Init(project);

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
