using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using CrossPlatform.Extensions;
using CrossPlatform.Services;
using Xunit;

namespace CrossPlatform.Tests.Services
{
    public class UserInterfaceServiceTests
    {
        private readonly UserInterfaceService _service;

        public UserInterfaceServiceTests()
        {
            var services = new ServiceCollection();
            services.AddCrossPlatformServices();
            _service = services.BuildServiceProvider().GetRequiredService<UserInterfaceService>();
        }

        [Fact]
        public void GetSupportedPlatforms_ReturnsAllPlatforms()
        {
            var platforms = _service.GetSupportedPlatforms().ToList();
            Assert.Contains("linux", platforms);
            Assert.Contains("macOS", platforms);
            Assert.Contains("windows", platforms);
        }

        [Theory]
        [InlineData("linux")]
        [InlineData("macOS")]
        [InlineData("windows")]
        public void CreateUserInterface_ValidPlatform_WritesExpectedOutput(string platform)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _service.CreateUserInterface(platform);

            var result = output.ToString();
            Assert.Contains("Rendering", result);
            Assert.Contains("Login form created successfully", result);
        }

        [Fact]
        public void CreateUserInterface_InvalidPlatform_ThrowsNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(() => _service.CreateUserInterface("invalid"));
        }
    }
}