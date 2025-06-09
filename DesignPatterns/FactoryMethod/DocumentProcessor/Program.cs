using System;
using DocumentProcessor.Services;
using DocumentProcessor.Models;
using System.Collections.Generic;

namespace DocumentProcessor;

public class Program
{
  public static void Main()
  {
    Console.WriteLine("Factory Method\n");
    Console.WriteLine("Tightly coupled approach");

    var coupledProcessor = new DocumentProcessorBad();

    try
    {
      coupledProcessor.ProcessDocument("pdf", "Sample PDF content");
      Console.WriteLine();
      coupledProcessor.ProcessDocument("word", "Sample Word content");
      // What would happen if we would need to add PowerPoint support ?
      // We would be violating design principles
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine($"\n{new string('-', 15)}\n");

    Console.WriteLine("Applied Factory Method");

    var factories = new DocumentProcessorFactory[]
    {
        new PdfProcessorFactory(),
        new WordProcessorFactory(),
        new ExcelProcessorFactory()
    };
    var documentService = new DocumentService(factories);

    var documentExamples = new Dictionary<DocumentType, string>
    {
        { DocumentType.Pdf, "Important PDF contract content" },
        { DocumentType.Word, "Meeting notes and action items" },
        { DocumentType.Excel, "Financial data in tables" }
    };

    foreach (var (type, content) in documentExamples)
    {
        try
        {
            documentService.ProcessDocument(type, content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing {type}: {ex.Message}\n");
        }
    }
  }
}