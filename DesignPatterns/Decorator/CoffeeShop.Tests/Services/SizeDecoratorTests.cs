using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Models.Components;
using CoffeeShop.Services.Decorator;
using Xunit;

namespace CoffeeShop.Tests.Services
{
    public class SizeDecoratorTests
    {
        [Theory]
        [InlineData("small", 0, 0)]
        [InlineData("medium", 0.50, 20)]
        [InlineData("large", 1.00, 40)]
        public void GetCostAndCalories_AppliesSizeModifiers(string size, decimal extraCost, int extraCal)
        {
            ICoffee espresso = new Espresso();
            var decorated = new SizeDecorator(espresso, size);
            Assert.Equal(espresso.GetCost() + extraCost, decorated.GetCost());
            Assert.Equal(espresso.GetCalories() + extraCal, decorated.GetCalories());
            Assert.Equal(size, decorated.GetSize());
        }
    }
}