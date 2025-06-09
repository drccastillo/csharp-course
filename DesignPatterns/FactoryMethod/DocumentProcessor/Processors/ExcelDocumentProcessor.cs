using DocumentProcessor.Interfaces;

namespace DocumentProcessor.Processors;

public class ExcelDocumentProcessor : IDocumentProcessor
{
  public void ProcessDocument(string content)
  {
    Console.WriteLine("Processing Excel document");
    Console.WriteLine($"Converting Excel content: {content}");
    Console.WriteLine($"Excel processing completed with spreadsheet format");
  }

}