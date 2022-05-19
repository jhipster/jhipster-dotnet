using AutoFixture;
using BlazorWebClient.Services.Api;
using FluentAssertions;
using JHipster.NetLite.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BlazorWebClient.Tests;

[TestClass]
public class ApiServiceTests
{
    private Mock<IApiService> _apiService;

    private Fixture _fixture;

    public ApiServiceTests()
    {
        _apiService = new Mock<IApiService>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async Task Should_NotThrow_When_Init()
    {
        //Arrange
        var project = _fixture.Create<Project>();
        _apiService.Setup(service => service.Post(project)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _apiService.Object.Post(project);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
