namespace ShoppingCartSystem;

public class ShoppingCart
{
  private readonly List<ProductQuantity> items = new();
  private readonly ICartProcessor processor;

  public ShoppingCart(ICartProcessor processor)
  {
    this.processor = processor;
  }

  public void AddItem(IProduct product, int quantity = 1)
  {
    items.Add(new ProductQuantity(product, quantity));
  }

  public void DisplayCart()
  {
    Console.WriteLine("\n=== Shopping Cart ===");
    foreach (var item in items)
    {
      Console.WriteLine($"{item.Quantity} x {item.Product.Name} @ {item.Product.Price:C} = {(item.Product.Price * item.Quantity):C}");
    }
  }

  public void Checkout()
  {
    processor.Process(items);
  }
}