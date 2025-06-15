using System;
using System.Collections.Generic;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;

namespace CoffeeShop.Services.Decorator;

/// <summary>
/// Concrete Decorator adding milk to the coffee.
/// </summary>
public class MilkDecorator : CoffeeDecorator
{
    private readonly string _milkType;
    private readonly decimal _additionalCost;
    private readonly int _additionalCalories;

    public MilkDecorator(ICoffee coffee, string milkType) : base(coffee)
    {
        _milkType = milkType ?? throw new ArgumentNullException(nameof(milkType));
        _additionalCost = milkType.ToLowerInvariant() switch
        {
            "regular" => 0.60m,
            "soy" => 0.75m,
            "coconut" => 0.90m,
            _ => 0.60m
        };
        _additionalCalories = milkType.ToLowerInvariant() switch
        {
            "regular" => 150,
            "soy" => 50,
            "coconut" => 70,
            _ => 150
        };
    }

    public override string GetDescription() => $"{_coffee.GetDescription()}, {_milkType} Milk";

    public override decimal GetCost() => _coffee.GetCost() + _additionalCost;

    public override int GetCalories() => _coffee.GetCalories() + _additionalCalories;

    public override List<Ingredient> GetIngredients()
    {
        var ingredients = new List<Ingredient>(_coffee.GetIngredients());
        ingredients.Add(new Ingredient($"{_milkType} Milk", _additionalCost, _additionalCalories));
        return ingredients;
    }
}