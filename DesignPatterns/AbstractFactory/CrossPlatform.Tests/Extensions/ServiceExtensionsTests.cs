using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using CrossPlatform.Extensions;
using CrossPlatform.Interfaces;
using CrossPlatform.Services;
using CrossPlatform.Cli;
using Xunit;

namespace CrossPlatform.Tests.Extensions
{
    public class ServiceExtensionsTests
    {
        [Fact]
        public void AddCrossPlatformServices_RegistersExpectedFactoriesAndServices()
        {
            var services = new ServiceCollection();
            services.AddCrossPlatformServices();
            var sp = services.BuildServiceProvider();

            var factories = sp.GetServices<IUserInterfaceComponentFactory>().ToList();
            Assert.Equal(3, factories.Count);
            var names = factories.Select(f => f.GetPlatformName());
            Assert.Contains("linux", names);
            Assert.Contains("macOS", names);
            Assert.Contains("windows", names);

            Assert.NotNull(sp.GetService<UserInterfaceService>());
            Assert.NotNull(sp.GetService<UserInterfaceCli>());
        }
    }
}