namespace ShoppingCartSystem;

public class ConsoleCartProcessor : ICartProcessor
{
  public void Process(IEnumerable<ProductQuantity> items)
  {
    Console.WriteLine("\n=== Checkout ===");
    decimal total = 0;

    foreach (var item in items)
    {
      var subtotal = item.Product.Price * item.Quantity;
      total += subtotal;

      if (item.Product is IShippable shippable)
      {
        var shipping = shippable.CalculateShipping();
        total += shipping;
        shippable.Ship();
      }
      else if (item.Product is IDownloadable downloadable)
      {
        downloadable.Download();
      }
    }

    Console.WriteLine($"Total Amount: {total:C}");
  }
}