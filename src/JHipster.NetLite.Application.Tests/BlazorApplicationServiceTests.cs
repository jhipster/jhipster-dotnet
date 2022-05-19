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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Application.Tests
{
    [TestClass]
    public class BlazorApplicationServiceTests
    {

        private IBlazorApplicationService _blazorApplicationService;

        private Mock<IBlazorDomainService> _blazorDomainService;

        private ILogger<BlazorApplicationService> _logger = new NullLogger<BlazorApplicationService>();

        private Fixture _fixture = new Fixture();

        public BlazorApplicationServiceTests()
        {
            _blazorDomainService = new Mock<IBlazorDomainService>();
            _blazorApplicationService = new BlazorApplicationService(_blazorDomainService.Object, _logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = _fixture.Create<Project>();
            _blazorDomainService.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await _blazorApplicationService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}

