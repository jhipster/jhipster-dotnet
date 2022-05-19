using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Application.Tests
{
    [TestClass]
    public class ApiApplicationServiceTests
    {

        private IApiApplicationService _apiApplicationService;

        private Mock<IApiDomainService> _apiDomainService;

        private ILogger<ApiApplicationService> _logger = new NullLogger<ApiApplicationService>();

        private Fixture _fixture = new Fixture();

        public ApiApplicationServiceTests()
        {
            _apiDomainService = new Mock<IApiDomainService>();
            _apiApplicationService = new ApiApplicationService(_apiDomainService.Object, _logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = _fixture.Create<Project>();
            _apiDomainService.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await _apiApplicationService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
