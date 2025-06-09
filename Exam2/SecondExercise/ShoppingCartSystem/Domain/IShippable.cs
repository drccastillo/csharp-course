namespace ShoppingCartSystem;

public interface IShippable
{
  decimal Weight { get; }
  decimal CalculateShipping();
  void Ship();
}