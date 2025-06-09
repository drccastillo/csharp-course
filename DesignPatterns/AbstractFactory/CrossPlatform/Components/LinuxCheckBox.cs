using System;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Components;

public sealed class LinuxCheckBox : ICheckBox
{
    private const string PlatformName = "Linux";
    private const string Style = "GTK";
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