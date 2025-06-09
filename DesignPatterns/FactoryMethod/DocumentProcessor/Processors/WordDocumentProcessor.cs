using DocumentProcessor.Interfaces;

namespace DocumentProcessor.Processors;

public class WordDocumentProcessor : IDocumentProcessor
{
  public void ProcessDocument(string content)
  {
    Console.WriteLine("Processing Word document");
    Console.WriteLine($"Converting Word content: {content}");
    Console.WriteLine($"Word processing completed with Microsoft format");
  }

}