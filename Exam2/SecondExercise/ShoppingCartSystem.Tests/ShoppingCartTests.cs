using System.Collections.Generic;
using Moq;
using Xunit;

namespace ShoppingCartSystem.Tests;

public class ShoppingCartTests
{
  [Fact]
  public void AddItem_ShouldStoreProductAndQuantity()
  {
    var processorMock = new Mock<ICartProcessor>();
    var cart = new ShoppingCart(processorMock.Object);
    var product = new Mock<IProduct>().Object;

    cart.AddItem(product, 3);
    cart.Checkout();

    processorMock.Verify(p => p.Process(It.Is<IEnumerable<ProductQuantity>>(items =>
      items.Any(i => i.Product == product && i.Quantity == 3))), Times.Once);
  }

  [Fact]
  public void Checkout_ShouldCalculateCorrectTotal()
  {
    var laptop = new PhysicalProduct { Name = "Laptop", Price = 1000m, Weight = 2m };
    var ebook = new DigitalProduct { Name = "EBook", Price = 20m, DownloadUrl = "url" };

    var processor = new TestCartProcessor();
    var cart = new ShoppingCart(processor);
    cart.AddItem(laptop);
    cart.AddItem(ebook);
    cart.Checkout();

    // Total = 1000 + 2*0.5 + 20 = 1021
    Assert.Equal(1021m, processor.Total);
  }

  private class TestCartProcessor : ICartProcessor
  {
    public decimal Total { get; private set; } = 0;

    public void Process(IEnumerable<ProductQuantity> items)
    {
      foreach (var item in items)
      {
        var subtotal = item.Product.Price * item.Quantity;
        Total += subtotal;

        if (item.Product is IShippable s)
          Total += s.CalculateShipping();
      }
    }
  }
}
