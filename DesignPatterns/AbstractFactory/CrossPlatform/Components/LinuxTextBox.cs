using System;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class LinuxTextBox : ITextBox
{
    private const string PlatformName = "Linux";
    private const string DefaultFont = "Liberation Mono";
    private string _text = string.Empty;

    public void SetText(string text) => _text = text;

    public string GetText() => _text;

    public string GetFont() => DefaultFont;

    public void Render()
    {
        Console.WriteLine($"Rendering {PlatformName} TextBox with font {GetFont()} and text '{_text}'");
    }
}