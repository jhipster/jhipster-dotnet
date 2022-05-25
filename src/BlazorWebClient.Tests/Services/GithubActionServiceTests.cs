using AutoFixture;
using BlazorWebClient.Services.GithubAction;
using BlazorWebClient.Services.Interfaces;
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
public class GithubActionServiceTests
{
    private Mock<IGithubActionService> _githubActionService;

    private Fixture _fixture;

    public GithubActionServiceTests()
    {
        _githubActionService = new Mock<IGithubActionService>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async Task Should_NotThrow_When_Init()
    {
        //Arrange
        var projecDto = _fixture.Create<ProjectDto>();
        _githubActionService.Setup(service => service.Post(projecDto)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _githubActionService.Object.Post(projecDto);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
