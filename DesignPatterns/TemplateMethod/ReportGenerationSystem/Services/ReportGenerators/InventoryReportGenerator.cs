using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Templates;

namespace ReportGenerationSystem.Services.ReportGenerators;

/// <summary>
/// Generator for Inventory reports using the template method.
/// </summary>
public class InventoryReportGenerator : ReportGenerator
{
    public InventoryReportGenerator(IReportFormatStrategy? formatStrategy = null) : base(formatStrategy) { }

    protected override ReportType GetReportType() => ReportType.Inventory;

    protected override string[] FetchData()
    {
        Console.WriteLine("Fetching Inventory data from database...");
        return new[] { "Product A: 50 units", "Product B: 30 units", "Product C: 10 units" };
    }

    protected override List<string> ProcessData(string[] rawData)
    {
        Console.WriteLine("Processing Inventory data: filtering out-of-stock items...");
        return rawData.Where(d => !d.Contains(": 0 units")).Select(d => d.ToUpper()).ToList();
    }

  // protected override string FormatReport(List<string> processedData)
  // {
  //   Console.WriteLine("Formatting sales to report as CSV...");
  //   var report = "Product,Quantity\n";

  //   foreach (var item in processedData)
  //   {
  //     var parts = item.Split(':');
  //     report += $"{parts[0]},{parts[1].Trim()}\n";
  //   }

  //   return report;
  // }
}