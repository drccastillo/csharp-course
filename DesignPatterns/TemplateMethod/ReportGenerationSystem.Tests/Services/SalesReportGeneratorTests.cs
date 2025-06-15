using System;
using System.Collections.Generic;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.ReportGenerators;
using ReportGenerationSystem.Services.Strategies;
using Xunit;

namespace ReportGenerationSystem.Tests.Services
{
    public class SalesReportGeneratorTests
    {
        [Fact]
        public void GenerateReport_ReturnsHtmlContent_WhenDefaultStrategy()
        {
            var generator = new SalesReportGenerator();
            var report = generator.GenerateReport();
            Assert.Contains("<html>", report);
        }

        [Fact]
        public void GenerateReport_ReturnsCsvContent_WhenCsvStrategy()
        {
            var generator = new SalesReportGenerator(new CSVFormatStrategy());
            var report = generator.GenerateReport();
            Assert.Contains("Item,Details", report);
        }
    }
}