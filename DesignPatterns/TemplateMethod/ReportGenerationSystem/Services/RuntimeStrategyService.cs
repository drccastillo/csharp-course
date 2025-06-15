using System;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.ReportGenerators;
using ReportGenerationSystem.Services.Strategies;

namespace ReportGenerationSystem.Services;

public class RuntimeStrategyService
{
  public void DemonstrateRuntimeSwitching()
  {
    // Let's think that we created this generator type from service
        var salesReport = new SalesReportGenerator();

    Console.WriteLine("Starting with HTML format:");
    salesReport.GenerateReport();

    // Let's assume that we have a UI ans someone changed the format to be exported to CSV
    Console.WriteLine("Switching to CSV format at runtime");
        salesReport.SetFormatStrategy(new CSVFormatStrategy());
    salesReport.GenerateReport();
  }
}