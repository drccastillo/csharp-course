using System;
using DocumentProcessor.Interfaces;

namespace DocumentProcessor.Processors;

public class PdfDocumentProcessor : IDocumentProcessor
{
  public void ProcessDocument(string content)
  {
    Console.WriteLine("Processing PDF document");
    Console.WriteLine($"Converting PDF content: {content}");
    Console.WriteLine($"PDF processing completed with Adobe format");
  }

}