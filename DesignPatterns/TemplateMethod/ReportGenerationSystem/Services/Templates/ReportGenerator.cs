using System;
using System.Collections.Generic;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Strategies;

namespace ReportGenerationSystem.Services.Templates;

/// <summary>
/// Template Method base class defining the report workflow.
/// </summary>
public abstract class ReportGenerator
{
    protected IReportFormatStrategy _formatStrategy;

    protected ReportGenerator(IReportFormatStrategy? formatStrategy = null)
    {
        _formatStrategy = formatStrategy ?? new HTMLFormatStrategy();
    }

    /// <summary>
    /// Changes the reporting format strategy.
    /// </summary>
    public void SetFormatStrategy(IReportFormatStrategy formatStrategy)
    {
        _formatStrategy = formatStrategy ?? throw new ArgumentNullException(nameof(formatStrategy));
        Console.WriteLine($"Format strategy changed to: {formatStrategy.FormatType}");
    }

    /// <summary>
    /// Executes the report generation workflow.
    /// </summary>
    public string GenerateReport()
    {
        Console.WriteLine($"\nGenerating {GetReportType()} report");

        var rawData = FetchData();
        var processedData = ProcessData(rawData);
        var formattedReport = _formatStrategy.FormatReport(processedData, GetReportType());
        SaveReport(formattedReport);

        return formattedReport;
    }

    /// <summary>
    /// Returns the report type for this generator.
    /// </summary>
    protected abstract ReportType GetReportType();

    /// <summary>
    /// Fetches raw data to be processed.
    /// </summary>
    protected abstract string[] FetchData();

    /// <summary>
    /// Processes raw data into a list of strings.
    /// </summary>
    protected abstract List<string> ProcessData(string[] rawData);

  protected virtual void SaveReport(string report)
  {
    Console.WriteLine($"💾 Saving {GetReportType()} report to file...");
    Console.WriteLine($"Report saved successfully: {report.Length} characters\n");
  }
}