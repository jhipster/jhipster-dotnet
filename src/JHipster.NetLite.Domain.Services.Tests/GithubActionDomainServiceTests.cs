// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services.Tests
{
    [TestClass]
    public class GithubActionDomainServiceTests
    {
        private IGithubActionDomainService _apiDomainService;

        private ILogger<InitDomainService> _loggerInit = new NullLogger<InitDomainService>();

        private ILogger<GithubActionDomainService> _loggerGithubAction = new NullLogger<GithubActionDomainService>();

        private string _currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string _projectFolder;

        private Fixture _fixture = new Fixture();

        private Project _project;

        public GithubActionDomainServiceTests()
        {
            _apiDomainService = new GithubActionDomainService(new ProjectLocalRepository(_loggerInit), _loggerGithubAction);
            _project = _fixture.Create<Project>();
            _projectFolder = Path.Join(_currentFolder, _project.Folder);
            Directory.CreateDirectory(_projectFolder);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            Func<Task> task = async () => await _apiDomainService.Init(_project);

            //Assert
            await task.Should().NotThrowAsync();

            Directory.Delete(_project.Folder, true);
        }


    }
}
