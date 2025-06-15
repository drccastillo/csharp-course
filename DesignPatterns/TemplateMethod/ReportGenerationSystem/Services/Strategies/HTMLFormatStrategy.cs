using System;
using System.Collections.Generic;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Services.Strategies;

/// <summary>
/// Concrete strategy for formatting reports as HTML.
/// </summary>
public class HTMLFormatStrategy : IReportFormatStrategy
{
    public FormatType FormatType => FormatType.Html;

    public string GetFileExtension() => ".html";

    public string FormatReport(List<string> processedData, ReportType reportType)
    {
        Console.WriteLine($"Formatting {reportType} report as HTML...");

        var html = $"<html><body><h1>{reportType} Report</h1>";
        foreach (var item in processedData)
        {
            html += $"<p>{item}</p>";
        }
        html += "</body></html>";

        return html;
    }
}