using CoffeeShop.Interfaces;
using CoffeeShop.Models.Components;
using CoffeeShop.Services.Builder;
using CoffeeShop.Services.Decorator;
using Xunit;

namespace CoffeeShop.Tests.Services
{
    public class CoffeeOrderBuilderTests
    {
        [Fact]
        public void Build_OrderWithDecorators_AppliesDecoratorsInSequence()
        {
            ICoffee baseCoffee = new Espresso();
            var order = new CoffeeOrderBuilder(baseCoffee)
                .WithSize("Large")
                .WithMilk("Regular")
                .WithSugar(1, "White")
                .Build();

            Assert.Contains("Espresso", order.GetDescription());
            Assert.Contains("Large", order.GetDescription());
            Assert.Contains("1 packet", order.GetDescription());
            Assert.True(order.GetCost() > baseCoffee.GetCost());
            Assert.True(order.GetCalories() > baseCoffee.GetCalories());
        }
    }
}