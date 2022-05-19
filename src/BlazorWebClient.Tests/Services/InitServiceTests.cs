using AutoFixture;
using BlazorWebClient.Services.Init;
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
public class InitServiceTests
{
    private Mock<IInitService> _initService;

    private Fixture _fixture;

    public InitServiceTests()
    {
        _initService = new Mock<IInitService>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async Task Should_NotThrow_When_Init()
    {
        //Arrange
        var project = _fixture.Create<Project>();
        _initService.Setup(service => service.Post(project)).Returns(Task.FromResult(true));

        //Act
        Func<Task> task = async () => await _initService.Object.Post(project);

        //Assert
        await task.Should().NotThrowAsync();
    }
}
