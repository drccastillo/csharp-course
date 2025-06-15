using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Templates;

namespace ReportGenerationSystem.Services.ReportGenerators;

/// <summary>
/// Generator for Sales reports using the template method.
/// </summary>
public class SalesReportGenerator : ReportGenerator
{
    public SalesReportGenerator(IReportFormatStrategy? formatStrategy = null) : base(formatStrategy) { }

    protected override ReportType GetReportType() => ReportType.Sales;

    protected override string[] FetchData()
    {
        Console.WriteLine("Fetching sales data from database...");
        return new[] { "Sale 1: $100", "Sale 2: $200", "Sale 3: $400" };
    }

    protected override List<string> ProcessData(string[] rawData)
    {
        Console.WriteLine("Processing sales data: converting to uppercase and filtering...");
        return rawData.Select(d => d.ToUpper()).Where(d => d.Contains('$')).ToList();
    }

  // protected override string FormatReport(List<string> processedData)
  // {
  //   Console.WriteLine("Formatting sales to report as HTML...");
  //   var report = "<html><body><h1>Sales Report</h1>";

  //   foreach (var item in processedData)
  //   {
  //     report += $"<p>{item}</p>";
  //   }

  //   report += "</body></html>";

  //   return report;
  // }
}