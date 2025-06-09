using Xunit;

namespace ShoppingCartSystem.Tests;

public class ProductTests
{
  [Fact]
  public void PhysicalProduct_ShouldCalculateShippingCorrectly()
  {
    var product = new PhysicalProduct { Name = "Box", Price = 100m, Weight = 3m };
    Assert.Equal(1.5m, product.CalculateShipping());
  }

  [Fact]
  public void DigitalProduct_ShouldReturnDownloadUrl()
  {
    var product = new DigitalProduct { Name = "Guide", Price = 15m, DownloadUrl = "http://example.com/file" };
    Assert.Equal("http://example.com/file", product.DownloadUrl);
  }

  [Fact]
  public void PhysicalProduct_Ship_ShouldOutputMessage()
  {
    var product = new PhysicalProduct { Name = "Book", Price = 50m, Weight = 1m };
    var output = new StringWriter();
    Console.SetOut(output);
    product.Ship();
    Assert.Contains("Shipping physical product: Book", output.ToString());
  }

  [Fact]
  public void DigitalProduct_Download_ShouldOutputMessage()
  {
    var product = new DigitalProduct { Name = "Tutorial", Price = 5m, DownloadUrl = "http://example.com" };
    var output = new StringWriter();
    Console.SetOut(output);
    product.Download();
    Assert.Contains("Downloading from: http://example.com", output.ToString());
  }
}
