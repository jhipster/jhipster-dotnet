// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

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
    public class GithubActionApplicationServiceTests
    {

        private IGithubActionApplicationService _githubActionApplicationService;

        private Mock<IGithubActionDomainService> _githubActionDomainService;

        private ILogger<GithubActionApplicationService> _logger = new NullLogger<GithubActionApplicationService>();

        private Fixture _fixture = new Fixture();

        public GithubActionApplicationServiceTests()
        {
            _githubActionDomainService = new Mock<IGithubActionDomainService>();
            _githubActionApplicationService = new GithubActionApplicationService(_githubActionDomainService.Object, _logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = _fixture.Create<Project>();
            _githubActionDomainService.Setup(m => m.Init(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await _githubActionApplicationService.Init(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
