using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ShoppingCartSystem.Cli;

public class Program
{
  public static void Main(string[] args)
  {
    Host.CreateDefaultBuilder(args)
      .ConfigureServices((_, services) =>
      {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<ICartProcessor, ConsoleCartProcessor>();
        services.AddSingleton<ShoppingCart>();
        services.AddSingleton<CartRunner>();
      })
      .Build()
      .Services
      .GetRequiredService<CartRunner>()
      .Run(args);
  }
}