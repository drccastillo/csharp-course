using System;
using System.IO;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services;
using Xunit;

namespace ReportGenerationSystem.Tests.Services
{
    public class ReportServiceTests
    {
        [Fact]
        public void GenerateAllReportsInFormat_WritesReportsWithoutError()
        {
            var service = new ReportService();
            var sw = new StringWriter();
            Console.SetOut(sw);
            service.GenerateAllReportsInFormat(FormatType.Csv);
            var output = sw.ToString();
            Assert.NotEmpty(output);
        }
    }
}