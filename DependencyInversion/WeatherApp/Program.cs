using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WeatherApp.Cli;
using WeatherApp.Extensions;
using Microsoft.Extensions.Configuration;

var builder = Host.CreateApplicationBuilder(args);
var services = builder.Services;

var useDefault = builder.Configuration.GetValue<bool>("UseDefault", true);
services.AddCliServices(useDefault);

using var host = builder.Build();
await host.Services.GetRequiredService<WeatherCli>().RunAsync(args);