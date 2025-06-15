using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Strategies;

namespace ReportGenerationSystem.Services.Factories;

public static class FormatStrategyFactory
{
    /// <summary>
    /// Creates the report format strategy based on the format type.
    /// </summary>
    public static IReportFormatStrategy CreateStrategy(FormatType formatType)
    {
        return formatType switch
        {
            FormatType.Html => new HTMLFormatStrategy(),
            FormatType.Csv => new CSVFormatStrategy(),
            FormatType.Json => new JSONFormatStrategy(),
            _ => throw new ArgumentException($"Unknown format: {formatType}")
        };
    }

    /// <summary>
    /// Returns the available format types.
    /// </summary>
    public static IReadOnlyList<FormatType> GetAvailableFormats()
        => Enum.GetValues<FormatType>().ToList();
}