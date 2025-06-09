namespace ShoppingCartSystem;

public class PhysicalProduct : IProduct, IShippable
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public decimal Weight { get; set; }
  
  private const decimal ShippingRatePerKg = 0.5m;
  public decimal CalculateShipping() => Weight * ShippingRatePerKg;

  public void Ship() => Console.WriteLine($"Shipping physical product: {Name}");
}