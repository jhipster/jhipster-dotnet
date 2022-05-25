using AutoFixture;
using BlazorWebClient.Services.Sonar;
using FluentAssertions;
using JHipster.NetLite.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebClient.Tests.Services;

[TestClass]
public class SonarServiceTests
{
    private Mock<ISonarService> _initService;

    private Fixture _fixture;

    public SonarServiceTests()
    {
        _initService = new Mock<ISonarService>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async Task Should_NotThrow_When_Init()
    {
        //Arrange
        var projectDto = _fixture.Create<ProjectDto>();
        _initService.Setup(service => service.Post(projectDto)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _initService.Object.Post(projectDto);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
