using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CrossPlatform.Cli;
using CrossPlatform.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddCrossPlatformServices();

using var host = builder.Build();
var cli = host.Services.GetRequiredService<UserInterfaceCli>();
cli.Run(args);
