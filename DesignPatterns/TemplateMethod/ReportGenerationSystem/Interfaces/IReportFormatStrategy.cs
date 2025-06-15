using System.Collections.Generic;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Interfaces;

/// <summary>
/// Strategy interface for formatting reports.
/// </summary>
public interface IReportFormatStrategy
{
    /// <summary>
    /// Gets the output format type.
    /// </summary>
    FormatType FormatType { get; }

    /// <summary>
    /// Formats the processed report data according to the strategy.
    /// </summary>
    string FormatReport(List<string> processedData, ReportType reportType);

    /// <summary>
    /// File extension for this format (e.g., .html, .csv, .json).
    /// </summary>
    string GetFileExtension();
}