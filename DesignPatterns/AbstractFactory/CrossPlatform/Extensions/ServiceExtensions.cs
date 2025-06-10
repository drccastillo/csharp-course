using Microsoft.Extensions.DependencyInjection;
using CrossPlatform.Cli;
using CrossPlatform.Services;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCrossPlatformServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserInterfaceComponentFactory, LinuxUserInterfaceFactory>();
            services.AddSingleton<IUserInterfaceComponentFactory, MacOSUserInterfaceFactory>();
            services.AddSingleton<IUserInterfaceComponentFactory, WindowsUserInterfaceFactory>();
            services.AddSingleton<UserInterfaceService>();
            services.AddSingleton<UserInterfaceCli>();
            return services;
        }
    }
}