using AutoFixture;
using BlazorWebClient.Services.GithubAction;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebClient.Tests;

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
        var project = _fixture.Create<Project>();
        _githubActionService.Setup(service => service.Post(project)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _githubActionService.Object.Post(project);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
