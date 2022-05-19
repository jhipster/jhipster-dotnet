using AutoFixture;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Repositories.Interfaces;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Domain.Services.Tests
{
    [TestClass]
    public class InitDomainServiceTests
    {
        private IInitDomainService _initDomainService;

        private ILogger<InitDomainService> _logger = new NullLogger<InitDomainService>();

        private string _currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string _projectFolder;

        private Fixture _fixture = new Fixture();

        private Project _project;

        public InitDomainServiceTests()
        {
            _initDomainService = new InitDomainService(new ProjectLocalRepository(_logger), _logger);
            _project = _fixture.Create<Project>();
            _projectFolder = Path.Join(_currentFolder, _project.Folder);
            Directory.CreateDirectory(_projectFolder);
        }

        [TestMethod]
        public async Task Should_NotThrow_When_Init()
        {
            //Arrange

            //Act
            Func<Task> task = async () => await _initDomainService.Init(_project);

            //Assert
            await task.Should().NotThrowAsync();

            var directory = new DirectoryInfo(_projectFolder) { Attributes = FileAttributes.Normal };

            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }

            directory.Delete(true);
        }


    }
}
