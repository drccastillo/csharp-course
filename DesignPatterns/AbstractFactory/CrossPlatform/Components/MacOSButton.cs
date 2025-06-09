using System;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class MacOSButton : IButton
{
    private const string PlatformName = "macOS";
    private const string Theme = "Cupertino";
    private bool _isPressed = false;

    public void Click()
    {
        _isPressed = !_isPressed;
        Console.WriteLine($"{PlatformName} Button clicked - State: {(_isPressed ? "Pressed" : "Released")}");
    }

    public string GetTheme() => Theme;

    public void Render()
    {
        Console.WriteLine($"Rendering {Theme} button");
    }
}