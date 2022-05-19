using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Application.Services;
using JHipster.NetLite.Application.Services.Interfaces;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JHipster.NetLite.Application.Tests
{
    [TestClass]
    public class InitApplicationServiceTests
    {

        private IInitApplicationService _initApplicationService;

        private Mock<IInitDomainService> _initDomainService;

        private ILogger<InitApplicationService> _logger = new NullLogger<InitApplicationService>();

        private Fixture _fixture = new Fixture();

        public InitApplicationServiceTests()
        {
            _initDomainService = new Mock<IInitDomainService>();
            _initApplicationService = new InitApplicationService(_initDomainService.Object, _logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = _fixture.Create<Project>();
            _initDomainService.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await _initApplicationService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
