using System;
using CrossPlatform.Client;
using CrossPlatform.Interfaces;
using CrossPlatform.Services;

var argsList = args.Length > 0 ? args : new[] { "windows" };
var platform = argsList[0].ToLowerInvariant();
IUserInterfaceComponentFactory factory = platform switch
{
    "windows" => new WindowsUserInterfaceFactory(),
    "macos"   => new MacOSUserInterfaceFactory(),
    "linux"   => new LinuxUserInterfaceFactory(),
    _ => throw new ArgumentException($"Unknown platform: {platform}")
};

var app = new UserInterfaceApplication(factory);
app.CreateLoginForm();
