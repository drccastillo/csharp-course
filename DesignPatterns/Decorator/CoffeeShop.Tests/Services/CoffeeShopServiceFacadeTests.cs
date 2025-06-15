using System;
using System.IO;
using CoffeeShop.Interfaces;
using CoffeeShop.Models.Components;
using CoffeeShop.Services.Builder;
using CoffeeShop.Services.Decorator;
using CoffeeShop.Services.Facade;
using Xunit;

namespace CoffeeShop.Tests.Services
{
    public class CoffeeShopServiceFacadeTests
    {
        [Fact]
        public void PrintReceipt_WritesReceiptToConsole()
        {
            var facade = new CoffeeShopServiceFacade();
            var coffee = new CoffeeOrderBuilder(new Espresso())
                .WithSize("Medium")
                .WithMilk("Regular")
                .Build();

            var sw = new StringWriter();
            Console.SetOut(sw);
            facade.PrintReceipt(coffee);
            var output = sw.ToString();
            Assert.Contains("----- Coffee Receipt -----", output);
            Assert.Contains("Order: Espresso", output);
            Assert.Contains("Size: Medium", output);
        }
    }
}