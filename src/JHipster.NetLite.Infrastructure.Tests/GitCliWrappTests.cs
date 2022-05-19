using FluentAssertions;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Infrastructure.Utils;
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

namespace JHipster.NetLite.Infrastructure.Tests
{

    [TestClass]
    public class GitCliWrappTests
    {

        private string _testPath = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestWrapper");

        private GitCliWrapper? _gitCliWrapp;

        private ILogger<InitDomainService> _logger = new NullLogger<InitDomainService>();

        [TestInitialize]
        public void InitTest()
        {
            if (Directory.Exists(_testPath))
            {
                Directory.Delete(_testPath, true);
            }
            Directory.CreateDirectory(_testPath);
            _gitCliWrapp = new GitCliWrapper(_testPath, "Jean.Dupont", "Jean.Dupont@gmail.com", _logger);
        }

        [TestMethod]
        public void Should_InitAndCommit_When_Calling()
        {

            //Arrange
            GitCliWrapper gitCliWrapper = new GitCliWrapper(_testPath, "Jean.Dupont", "Jean.Dupont@gmail.com", _logger);

            //Act
            gitCliWrapper.Init();

            File.Create(Path.Join(_testPath, "file.txt")).Close();
            gitCliWrapper.AddAll()
                         .Commit("message");

            //Assert
            new DirectoryInfo(Path.Join(_testPath, ".git")).Exists.Should().BeTrue();
            gitCliWrapper.GetCommits().ToArray().Should().HaveCount(1);

            var directory = new DirectoryInfo(_testPath) { Attributes = FileAttributes.Normal };

            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }

            directory.Delete(true);
        }
    }
}
