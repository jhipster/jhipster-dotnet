using AutoFixture;
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
public class BlazorServiceTests
{
    private Mock<IBlazorService> _blazorService;

    private Fixture _fixture;

    public BlazorServiceTests()
    {
        _blazorService = new Mock<IBlazorService>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async Task Should_NotThrow_When_Init()
    {
        //Arrange
        var projectDto = _fixture.Create<ProjectDto>();
        _blazorService.Setup(service => service.Post(projectDto)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _blazorService.Object.Post(projectDto);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
