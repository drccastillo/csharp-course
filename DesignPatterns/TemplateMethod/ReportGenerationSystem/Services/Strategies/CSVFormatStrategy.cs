using System;
using System.Collections.Generic;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Services.Strategies;

/// <summary>
/// Concrete strategy for formatting reports as CSV.
/// </summary>
public class CSVFormatStrategy : IReportFormatStrategy
{
    private readonly string _delimiter;

    public CSVFormatStrategy(string delimiter = ",")
    {
        _delimiter = delimiter;
    }

    public FormatType FormatType => FormatType.Csv;

    public string GetFileExtension() => ".csv";

    public string FormatReport(List<string> processedData, ReportType reportType)
    {
        Console.WriteLine($"Formatting {reportType} report as CSV with delimiter '{_delimiter}'...");

        var csv = $"Generated{_delimiter}{DateTime.Now:yyyy-MM-dd:HH:mm:ss}\n\n";
        csv += "Item" + _delimiter + "Details\n";
        foreach (var item in processedData)
        {
            var parts = item.Split(':');
            if (parts.Length >= 2)
            {
                csv += $"{parts[0].Trim()}{_delimiter}{parts[1].Trim()}\n";
            }
            else
            {
                csv += $"{item}{_delimiter}\n";
            }
        }

        return csv;
    }
}