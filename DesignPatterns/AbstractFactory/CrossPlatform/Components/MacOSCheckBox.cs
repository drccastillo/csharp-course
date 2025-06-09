using System;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class MacOSCheckBox : ICheckBox
{
    private const string PlatformName = "macOS";
    private const string Style = "Cupertino";
    private bool _isChecked = false;

    public void Check(bool isChecked)
    {
        _isChecked = isChecked;
        Console.WriteLine($"{PlatformName} CheckBox {(isChecked ? "Checked" : "Unchecked")}");
    }

    public bool IsChecked() => _isChecked;

    public string GetStyle() => Style;

    public void Render()
    {
        Console.WriteLine($"Rendering {Style} checkbox");
    }
}