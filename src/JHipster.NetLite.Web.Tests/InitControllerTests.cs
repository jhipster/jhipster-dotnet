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
using System.Net;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class InitControllerTests
    {
        private InitController _initController;

        private Mock<IInitApplicationService> _initApplicationService;

        private Fixture _fixture = new Fixture();

        private IMapper _mapper;

        private ILogger<InitController> _logger = new NullLogger<InitController>();

        public InitControllerTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(InitController)));
            _mapper = new Mapper(configuration);
            _initApplicationService = new Mock<IInitApplicationService>();
            _initController = new InitController(_logger, _initApplicationService.Object, _mapper);
        }

        [TestMethod]
        public async Task Should_ReturnBadRequest_When_Exception()
        {
            //Arrange
            _initApplicationService.Setup(app => app.Init(It.IsAny<Project>()))
                .Throws(new Exception("test unitaire"));

            //Act 
            var result = await _initController.Post(new ProjectDto("", "", "", "", "", ""));

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
            var result = await _initController.Post(_fixture.Create<ProjectDto>());

            //Assert
            var statusResult = result as OkResult;
            statusResult.Should().NotBeNull();
            statusResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
