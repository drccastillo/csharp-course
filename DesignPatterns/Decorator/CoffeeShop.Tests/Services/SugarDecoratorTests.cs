using CoffeeShop.Interfaces;
using CoffeeShop.Models;
using CoffeeShop.Models.Components;
using CoffeeShop.Services.Decorator;
using Xunit;

namespace CoffeeShop.Tests.Services
{
    public class SugarDecoratorTests
    {
        [Fact]
        public void GetCost_CalculatesCostBasedOnPacketsAndType()
        {
            ICoffee espresso = new Espresso();
            var decorated = new SugarDecorator(espresso, 2, "Brown");
            var costPerPacket = 0.40m;
            Assert.Equal(espresso.GetCost() + (costPerPacket * 2), decorated.GetCost());
        }

        [Fact]
        public void GetCalories_CalculatesCaloriesBasedOnPacketsAndType()
        {
            ICoffee espresso = new Espresso();
            var decorated = new SugarDecorator(espresso, 3, "White");
            var calPerPacket = 16;
            Assert.Equal(espresso.GetCalories() + (calPerPacket * 3), decorated.GetCalories());
        }

        [Fact]
        public void GetIngredients_IncludesSugarIngredient()
        {
            ICoffee espresso = new Espresso();
            var decorated = new SugarDecorator(espresso, 1, "Stevia");
            var ingredients = decorated.GetIngredients();
            Assert.Contains(ingredients, i => i.Name == "Stevia Sugar");
        }
    }
}