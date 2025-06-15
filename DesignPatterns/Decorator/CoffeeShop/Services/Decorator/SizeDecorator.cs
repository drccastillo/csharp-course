using System;
using System.Collections.Generic;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;

namespace CoffeeShop.Services.Decorator;

/// <summary>
/// Concrete Decorator adding size adjustment to the coffee.
/// </summary>
public class SizeDecorator : CoffeeDecorator
{
    private readonly string _size;
    private readonly decimal _extraCost;
    private readonly int _extraCalories;

    public SizeDecorator(ICoffee coffee, string size) : base(coffee)
    {
        _size = size ?? throw new ArgumentNullException(nameof(size));
        switch (size.ToLowerInvariant())
        {
            case "small":
                _extraCost = 0m;
                _extraCalories = 0;
                break;
            case "medium":
                _extraCost = 0.50m;
                _extraCalories = 20;
                break;
            case "large":
                _extraCost = 1.00m;
                _extraCalories = 40;
                break;
            default:
                _extraCost = 0m;
                _extraCalories = 0;
                break;
        }
    }

    public override string GetSize() => _size;

    public override string GetDescription() => $"{_coffee.GetDescription()} ({_size})";

    public override decimal GetCost() => _coffee.GetCost() + _extraCost;

    public override int GetCalories() => _coffee.GetCalories() + _extraCalories;

    public override List<Ingredient> GetIngredients()
    {
        var ingredients = new List<Ingredient>(_coffee.GetIngredients());
        ingredients.Add(new Ingredient($"{_size} size", _extraCost, _extraCalories));
        return ingredients;
    }
}