﻿// Licensed to the .NET Foundation under one or more agreements.
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
    public class SonarApplicationServiceTests
    {

        private ISonarApplicationService _sonarApplicationService;

        private Mock<ISonarDomainService> _sonarDomainService;

        private ILogger<SonarApplicationService> _logger = new NullLogger<SonarApplicationService>();

        private Fixture _fixture = new Fixture();

        public SonarApplicationServiceTests()
        {
            _sonarDomainService = new Mock<ISonarDomainService>();
            _sonarApplicationService = new SonarApplicationService(_sonarDomainService.Object, _logger);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange
            var project = _fixture.Create<Project>();
            _sonarDomainService.Setup(m => m.InitAsync(project)).Returns(Task.FromResult(true));

            //Act
            Func<Task> task = async () => await _sonarApplicationService.InitAsync(project);

            //Assert
            await task.Should().NotThrowAsync();
        }
    }
}
