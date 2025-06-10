using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using CrossPlatform.Extensions;
using CrossPlatform.Cli;
using Xunit;

namespace CrossPlatform.Tests.Cli
{
    public class UserInterfaceCliTests
    {
        private UserInterfaceCli CreateCli(TextWriter writer)
        {
            var services = new ServiceCollection();
            services.AddCrossPlatformServices();
            var sp = services.BuildServiceProvider();
            Console.SetOut(writer);
            return sp.GetRequiredService<UserInterfaceCli>();
        }

        [Fact]
        public void Run_NoArgs_PrintsUsageAndSupportedPlatforms()
        {
            var output = new StringWriter();
            var cli = CreateCli(output);

            cli.Run(Array.Empty<string>());

            var result = output.ToString();
            Assert.Contains("Usage:", result);
            Assert.Contains("Supported platforms:", result);
        }

        [Fact]
        public void Run_InvalidPlatform_PrintsErrorAndSupportedPlatforms()
        {
            var output = new StringWriter();
            var cli = CreateCli(output);

            cli.Run(new[] { "invalid" });

            var result = output.ToString();
            Assert.Contains("Error:", result);
            Assert.Contains("Supported platforms:", result);
        }

        [Fact]
        public void Run_ValidPlatform_CreatesUserInterface()
        {
            var output = new StringWriter();
            var cli = CreateCli(output);

            cli.Run(new[] { "linux" });

            var result = output.ToString();
            Assert.Contains("Rendering", result);
            Assert.Contains("Login form created successfully", result);
        }
    }
}