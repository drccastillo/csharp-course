using ReportGenerationSystem.Models;
using ReportGenerationSystem.Services;

var reportService = new ReportService();
reportService.GenerateAllReports();
reportService.GenerateAllReportsInFormat(FormatType.Csv);
