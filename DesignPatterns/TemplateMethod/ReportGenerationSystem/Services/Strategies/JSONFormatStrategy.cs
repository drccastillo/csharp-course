using System;
using System.Collections.Generic;
using System.Text.Json;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Services.Strategies;

/// <summary>
/// Concrete strategy for formatting report data as JSON.
/// </summary>
public class JSONFormatStrategy : IReportFormatStrategy
{
    public FormatType FormatType => FormatType.Json;

    public string GetFileExtension() => ".json";

    public string FormatReport(List<string> processedData, ReportType reportType)
    {
        Console.WriteLine($"Formatting {reportType} report as JSON...");
        var payload = new { ReportType = reportType.ToString(), Items = processedData };
        return JsonSerializer.Serialize(payload, new JsonSerializerOptions { WriteIndented = true });
    }
}