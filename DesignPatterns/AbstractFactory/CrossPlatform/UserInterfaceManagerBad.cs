using System;

namespace CrossPlatform;

public class UserInterfaceManagerBad
{
  private const string WindowsPlatform = "windows";
  private const string MacOSPlatform = "macos";
  private const string LinuxPlatform = "linux";

  // Violation of Open/Closed Principle - needs modification for new document type
  // Violation of Single Responsibility - knows about all document types
  // The code is repeated and tightly coupled
  public void CreateUserInterface(string platform)
  {
    if (platform.Equals("windows", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.WriteLine("Creating Windows UI");
      Console.WriteLine("- Windows Button with Aero theme");
      Console.WriteLine("- Windows TextBox with system font");
      Console.WriteLine("- Windows Checkbox with Windows styling");
    }
    else if (platform.Equals("macos", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.WriteLine("Creating macOS UI");
      Console.WriteLine("- macOS Button with Aero theme");
      Console.WriteLine("- macOS TextBox with system font");
      Console.WriteLine("- macOS Checkbox with macOS styling");
    }
    else if (platform.Equals("linux", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.WriteLine("Creating Linux UI");
      Console.WriteLine("- Linux Button with Aero theme");
      Console.WriteLine("- Linux TextBox with system font");
      Console.WriteLine("- Linux Checkbox with Linux styling");
    }
    else
    {
      throw new NotSupportedException($"Platform '{platform}' is not supported.");
    }
  }
}