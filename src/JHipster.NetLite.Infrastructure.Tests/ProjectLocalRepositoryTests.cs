using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using JHipster.NetLite.Domain.Services;
using JHipster.NetLite.Domain.Services.Interfaces;
using JHipster.NetLite.Infrastructure.Helpers;
using JHipster.NetLite.Infrastructure.Repositories;
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
    public class ProjectLocalRepositoryTest
    {
        private const string PathFile = "Init";

        private const string FileName = "Readme.md";

        private const string DataInitialisationToCopy = "Test text";

        private const string FileToCopy = "FileToCopy.txt";

        private const string SourceFolder = "TestCopy";

        private string _folder = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Test");

        private string _templateFolder = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Templates");

        private ProjectLocalRepository _projectRepository;

        private ILogger<InitDomainService> _logger = new NullLogger<InitDomainService>();

        public ProjectLocalRepositoryTest()
        {
            _projectRepository = new ProjectLocalRepository(_logger);
        }

        [TestInitialize]
        public async Task InitTest()
        {
            if (Directory.Exists(_folder))
            {
                Directory.Delete(_folder, true);
            }
            Directory.CreateDirectory(_folder);
            Directory.CreateDirectory(SourceFolder);
            Directory.CreateDirectory(Path.Join(_templateFolder, SourceFolder));
            await File.WriteAllTextAsync(Path.Join(_templateFolder, SourceFolder, FileToCopy), DataInitialisationToCopy);
        }

        [TestMethod]
        public async Task Should_TemplateReadme_When_Call()
        {
            //Arrange
            var folderPathBeforeTemplating = Path.Join(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Templates");

            //Act
            var textBeforeTemplating = await File.ReadAllTextAsync(Path.Join(folderPathBeforeTemplating, PathFile, MustacheHelper.WithExt(FileName)));
            await _projectRepository.Template(new Project(_folder, "", "", "", "", ""), PathFile, FileName);
            var textAfterTemplating = await File.ReadAllTextAsync(Path.Join(_folder, FileName));

            //Assert
            textBeforeTemplating.Should().NotBeEquivalentTo(textAfterTemplating);
        }

        [TestMethod]
        public async Task Should_TemplateMoveReadme_When_Call()
        {
            //Arrange
            var newPathFile = "Redirect";

            //Act
            await _projectRepository.Template(new Project(_folder, "", "", "", "", ""), PathFile, FileName, newPathFile);

            //Assert
            File.Exists(Path.Join(_folder, newPathFile, FileName)).Should().BeTrue();

        }

        [TestMethod]
        public async Task Should_TemplateMoveRenameReadme_When_Call()
        {
            //Arrange
            var newPathFile = "Redirect";
            var newPathName = "Suuuuu.md";

            //Act
            await _projectRepository.Template(new Project(_folder, "", "", "", "", ""), PathFile, FileName, newPathFile, newPathName);

            //Assert
            File.Exists(Path.Join(_folder, newPathFile, newPathName)).Should().BeTrue();

        }

        [TestMethod]
        public async Task Should_CopyText_When_Call()
        {
            //Arrange
            var textToCopy = await File.ReadAllTextAsync(Path.Join(Path.Join(_templateFolder, SourceFolder, FileToCopy)));

            //Act
            await _projectRepository.Add(_folder, SourceFolder, FileToCopy);

            //Assert
            textToCopy.Should().BeEquivalentTo(await File.ReadAllTextAsync(Path.Join(_folder, FileToCopy)));

            Directory.Delete(SourceFolder, true);
        }

        [TestMethod]
        public async Task Should_MoveCopyText_When_Call()
        {
            //Arrange
            var destinationFolder = "Redirect";
            var textToCopy = await File.ReadAllTextAsync(Path.Join(_templateFolder, SourceFolder, FileToCopy));

            //Act
            await _projectRepository.Add(_folder, SourceFolder, FileToCopy, destinationFolder);

            //Assert
            Directory.Exists(Path.Join(_folder, destinationFolder)).Should().BeTrue();
            textToCopy.Should().BeEquivalentTo(await File.ReadAllTextAsync(Path.Join(_folder, destinationFolder, FileToCopy)));

        }

        [TestMethod]
        public async Task Should_MoveCopyTextRename_When_Call()
        {
            //Arrange
            var destinationFolder = "Redirect";
            var destinationFileName = "Renamed.txt";
            var textToCopy = await File.ReadAllTextAsync(Path.Join(_templateFolder, SourceFolder, FileToCopy));

            //Act
            await _projectRepository.Add(_folder, SourceFolder, FileToCopy, destinationFolder, destinationFileName);

            //Assert
            Directory.Exists(Path.Join(_folder, destinationFolder)).Should().BeTrue();
            File.Exists(Path.Join(_folder, destinationFolder, destinationFileName)).Should().BeTrue();
            var textCopy = await File.ReadAllTextAsync(Path.Join(_folder, destinationFolder, destinationFileName));
            textToCopy.Should().BeEquivalentTo(textCopy);

        }

        [TestMethod]
        public void Should_InitGit_When_Call()
        {
            //Arrange
            File.Create(Path.Join(_folder, "file.txt")).Close();
            GitCliWrapper gitCliWrapper = new GitCliWrapper(_folder, "Jean.Dupont", "Jean.Dupont@gmail.com", _logger);

            //Act
            _projectRepository.InitGit(new Project(_folder, "", "", "", "Jean.Dupont", "jean.dupont@gmail.com"));

            //Assert
            new DirectoryInfo(Path.Join(_folder, ".git")).Exists.Should().BeTrue();
            gitCliWrapper.GetCommits().ToArray().Should().HaveCount(1);

            var directory = new DirectoryInfo(_folder) { Attributes = FileAttributes.Normal };

            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }

            directory.Delete(true);
        }
    }
}
