using System;
using ReportGenerationSystem.Models;
using Xunit;

namespace ReportGenerationSystem.Tests.Utils
{
    public class EnumTests
    {
        [Fact]
        public void FormatType_HasExpectedValues()
        {
            var values = Enum.GetNames<FormatType>();
            Assert.Contains("Html", values);
            Assert.Contains("Csv", values);
            Assert.Contains("Json", values);
        }

        [Fact]
        public void ReportType_HasExpectedValues()
        {
            var values = Enum.GetNames<ReportType>();
            Assert.Contains("Sales", values);
            Assert.Contains("Inventory", values);
            Assert.Contains("User", values);
        }
    }
}