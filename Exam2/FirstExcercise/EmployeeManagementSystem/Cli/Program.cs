using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagementSystem.Cli;

public class Program
{
  public static void Main(string[] args)
  {
    Host.CreateDefaultBuilder(args)
      .ConfigureServices((_, services) =>
      {
        services.AddSingleton<IFileService, TextFileService>();
        services.AddSingleton<INotifier, ConsoleNotifier>();
        services.AddSingleton<EmployeeManager>();
        services.AddSingleton<Runner>();
      })
      .Build()
      .Services
      .GetRequiredService<Runner>()
      .Run(args);
  }
}