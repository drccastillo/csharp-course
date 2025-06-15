using System;
using System.Collections.Generic;
using CoffeeShop.Interfaces;
using CoffeeShop.Models;

namespace CoffeeShop.Services.Decorator;

/// <summary>
/// Concrete Decorator adding sugar to the coffee.
/// </summary>
public class SugarDecorator : CoffeeDecorator
{
    private readonly int _packets;
    private readonly string _sugarType;

    public SugarDecorator(ICoffee coffee, int packets, string sugarType) : base(coffee)
    {
        _packets = packets;
        _sugarType = sugarType ?? throw new ArgumentNullException(nameof(sugarType));
    }

    public override string GetDescription()
    {
        var packetText = _packets == 1 ? "packet" : "packets";
        return $"{_coffee.GetDescription()}, {_packets} {packetText} of {_sugarType} Sugar";
    }

    public override decimal GetCost()
    {
        var costPerPacket = _sugarType.ToLowerInvariant() switch
        {
            "white" => 0.30m,
            "brown" => 0.40m,
            "stevia" => 0.50m,
            _ => 0.30m
        };
        return _coffee.GetCost() + (costPerPacket * _packets);
    }

    public override int GetCalories()
    {
        var caloriesPerPacket = _sugarType.ToLowerInvariant() switch
        {
            "white" => 16,
            "brown" => 15,
            "stevia" => 0,
            _ => 16
        };
        return _coffee.GetCalories() + (caloriesPerPacket * _packets);
    }

    public override List<Ingredient> GetIngredients()
    {
        var ingredients = new List<Ingredient>(_coffee.GetIngredients());
        ingredients.Add(new Ingredient($"{_sugarType} Sugar", GetCost() - _coffee.GetCost(), GetCalories() - _coffee.GetCalories()));
        return ingredients;
    }
}