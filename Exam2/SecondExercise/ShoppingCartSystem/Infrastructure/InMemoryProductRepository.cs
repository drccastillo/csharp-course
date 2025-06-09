namespace ShoppingCartSystem;

public class InMemoryProductRepository : IProductRepository
{
  private readonly Dictionary<string, IProduct> products = new()
  {
    ["Laptop"] = new PhysicalProduct { Name = "Laptop", Price = 1000m, Weight = 2.5m },
    ["Mouse"] = new PhysicalProduct { Name = "Mouse", Price = 25m, Weight = 0.2m },
    ["EBook"] = new DigitalProduct { Name = "EBook", Price = 10m, DownloadUrl = "https://example.com/ebook" }
  };

  public IProduct GetProduct(string name) => products.TryGetValue(name, out var p) ? p : throw new ArgumentException("Product not found");
}
