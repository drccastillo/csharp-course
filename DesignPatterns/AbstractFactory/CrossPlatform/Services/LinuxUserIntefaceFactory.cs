using CrossPlatform.Components;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Services;

public class LinuxUserInterfaceFactory : IUserInterfaceComponentFactory
{
    private const string PlatformName = "linux";

    public IButton CreateButton() => new LinuxButton();
    public ICheckBox CreateCheckBox() => new LinuxCheckBox();
    public ITextBox CreateTextBox() => new LinuxTextBox();
    public string GetPlatformName() => PlatformName;
}