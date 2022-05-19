// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using AutoFixture;
using AutoMapper;
using FluentAssertions;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Web.Controllers.Projects;
using JHipster.NetLite.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class GithubActionControllerTests
    {
        private GithubActionController _githubActionController;

        private Mock<IGithubActionApplicationService> _githubActionApplicationService;

        private Fixture _fixture = new Fixture();

        private IMapper _mapper;

        private ILogger<GithubActionController> _logger = new NullLogger<GithubActionController>();

        public GithubActionControllerTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(ApiController)));
            _mapper = new Mapper(configuration);
            _githubActionApplicationService = new Mock<IGithubActionApplicationService>();
            _githubActionController = new GithubActionController(_logger, _githubActionApplicationService.Object, _mapper);
        }

        [TestMethod]
        public async Task Should_ReturnBadRequest_When_Exception()
        {
            //Arrange
            _githubActionApplicationService.Setup(app => app.Init(It.IsAny<Project>()))
                .Throws(new Exception("test unitaire"));

            //Act 
            var result = await _githubActionController.Post(_fixture.Create<ProjectDto>());

            //Assert 
            var statusResult = result as BadRequestObjectResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Should_ReturnOkStatusCode_When_Call()
        {
            //Arrange

            //Act
            var result = await _githubActionController.Post(_fixture.Create<ProjectDto>());

            //Assert
            var statusResult = result as OkResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
