namespace CoffeeShop.Models;

/// <summary>
/// Value object representing an ingredient with cost and calories.
/// </summary>
public record Ingredient(string Name, decimal Cost, int Calories);