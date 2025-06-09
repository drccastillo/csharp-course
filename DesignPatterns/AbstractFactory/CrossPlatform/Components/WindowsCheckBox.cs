using System;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class WindowsCheckBox : ICheckBox
{
    private const string PlatformName = "Windows";
    private const string Style = "Aero";
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