using AutoFixture;
using BlazorWebClient.Services.Interfaces;
using FluentAssertions;
using JHipster.NetLite.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace BlazorWebClient.Tests.Services;

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
        var projectDto = _fixture.Create<ProjectDto>();
        _apiService.Setup(service => service.Post(projectDto)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _apiService.Object.Post(projectDto);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
