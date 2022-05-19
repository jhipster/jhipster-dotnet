using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHipster.NetLite.Web.Tests
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        private WebApplicationBuilder _builder;

        public ServiceCollectionExtensionsTests()
        {
            _builder = WebApplication.CreateBuilder();
        }

        [TestMethod]
        public void Should_NotThrow_When_Calling()
        {
            //Arrange


            //Act
            Action act = () => _builder.Services.AddControllers().AddJHipsterLite();

            //Assert
            act.Should().NotThrow();
        }
    }
}
