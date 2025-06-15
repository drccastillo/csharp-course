using System;
using System.Linq;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Factories;
using Xunit;

namespace ReportGenerationSystem.Tests.Services
{
    public class FormatStrategyFactoryTests
    {
        [Theory]
        [InlineData(FormatType.Html)]
        [InlineData(FormatType.Csv)]
        [InlineData(FormatType.Json)]
        public void CreateStrategy_ReturnsCorrectStrategy(FormatType format)
        {
            var strategy = FormatStrategyFactory.CreateStrategy(format);
            Assert.Equal(format, strategy.FormatType);
        }

        [Fact]
        public void GetAvailableFormats_ReturnsAllFormatTypes()
        {
            var formats = FormatStrategyFactory.GetAvailableFormats();
            foreach (var ft in Enum.GetValues<FormatType>())
            {
                Assert.Contains(ft, formats);
            }
        }
    }
}