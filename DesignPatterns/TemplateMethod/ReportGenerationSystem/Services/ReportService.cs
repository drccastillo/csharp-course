using System.Collections.Generic;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Factories;
using ReportGenerationSystem.Services.ReportGenerators;
using ReportGenerationSystem.Services.Templates;

namespace ReportGenerationSystem.Services;

public class ReportService
{
  public void GenerateAllReports()
  {
    var generators = new List<ReportGenerator>
    {
      new SalesReportGenerator(),
      new InventoryReportGenerator(),
      new UserReportGenerator()
    };

    foreach (var generator in generators)
    {
      generator.GenerateReport();
    }
  }

    /// <summary>
    /// Generates all reports using the specified format type.
    /// </summary>
    public void GenerateAllReportsInFormat(FormatType format)
    {
        var strategy = FormatStrategyFactory.CreateStrategy(format);

        var generators = new List<ReportGenerator>
        {
            new SalesReportGenerator(strategy),
            new InventoryReportGenerator(strategy),
            new UserReportGenerator(strategy)
        };

        foreach (var generator in generators)
        {
            generator.GenerateReport();
        }
    }
}