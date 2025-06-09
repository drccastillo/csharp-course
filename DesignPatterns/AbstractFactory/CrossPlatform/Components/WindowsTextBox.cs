using System;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class WindowsTextBox : ITextBox
{
    private const string PlatformName = "Windows";
    private const string DefaultFont = "Segoe UI";
    private string _text = string.Empty;

    public void SetText(string text) => _text = text;

    public string GetText() => _text;

    public string GetFont() => DefaultFont;

    public void Render()
    {
        Console.WriteLine($"Rendering {PlatformName} TextBox with font {GetFont()} and text '{_text}'");
    }
}