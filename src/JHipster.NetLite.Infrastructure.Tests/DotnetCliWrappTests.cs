using FluentAssertions;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Infrastructure.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace JHipster.NetLite.Infrastructure.Tests
{

    [TestClass]
    public class DotnetCliWrappTests
    {

        private const string DefaultExtension = ".sln";

        private string _testPath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestWrapper");

        private DotnetCliWrapper? _dotnetCliWrapp;

        private ILogger<InitDomainService> _logger = new NullLogger<InitDomainService>();

        [TestInitialize]
        public void InitTest()
        {
            if (Directory.Exists(_testPath))
            {
                Directory.Delete(_testPath, true);
            }
            Directory.CreateDirectory(_testPath);
            _dotnetCliWrapp = new DotnetCliWrapper(_testPath, _logger);
        }

        [TestMethod]
        public void Should_CreateNewSln_When_Calling()
        {
            //Arrange
            var solutionName = "Test";

            //Act
            _dotnetCliWrapp.NewSln(solutionName, false);

            //Assert
            File.Exists(Path.Join(_testPath, solutionName + DefaultExtension)).Should().BeTrue();
        }

        [TestMethod]
        public void Should_NotThrow_When_Build()
        {
            //Arrange

            //Act
            _dotnetCliWrapp.NewSln("Test", true);
            Action act = () => _dotnetCliWrapp.Build();

            //Assert
            act.Should().NotThrow();
        }
    }
}
