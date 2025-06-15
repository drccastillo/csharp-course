using System;
using System.Collections.Generic;
using System.Linq;
using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services.Templates;

namespace ReportGenerationSystem.Services.ReportGenerators;

/// <summary>
/// Generator for User reports using the template method.
/// </summary>
public class UserReportGenerator : ReportGenerator
{
    public UserReportGenerator(IReportFormatStrategy? formatStrategy = null) : base(formatStrategy) { }

    protected override ReportType GetReportType() => ReportType.User;

    protected override string[] FetchData()
    {
        Console.WriteLine("Fetching User data from database...");
        return new[] { "User: John (Active)", "User: Jane (Inactive)", "User: Michael (Active)" };
    }

    protected override List<string> ProcessData(string[] rawData)
    {
        Console.WriteLine("Processing User data: filtering active users only...");
        return rawData.Where(d => d.Contains("Active")).Select(d => d.ToUpper()).ToList();
    }

  // protected override string FormatReport(List<string> processedData)
  // {
  //   Console.WriteLine("Formatting sales to report as JSON...");
  //   var report = "{ \"users\": [";
  //   report += string.Join(", ", processedData.Select(u => $"\"{u}\""));
  //   report += "] }";

  //   return report;
  // }
}