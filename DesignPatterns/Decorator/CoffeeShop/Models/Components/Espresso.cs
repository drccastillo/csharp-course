namespace CoffeeShop.Models.Components;

/// <summary>
/// Concrete Component: Espresso base coffee.
/// </summary>
public class Espresso : BaseCoffee
{
    public Espresso() : base("Espresso", 2.50m, 5, "Medium") { }
}