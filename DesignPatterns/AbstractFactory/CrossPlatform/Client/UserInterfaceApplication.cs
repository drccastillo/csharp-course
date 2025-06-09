using System;
using System.Collections.Generic;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Client
{
public class UserInterfaceApplication
{
    private readonly IUserInterfaceComponentFactory _uiFactory;
    private readonly List<IButton> _buttons;
    private readonly List<ITextBox> _textBoxes;
    private readonly List<ICheckBox> _checkBoxes;

    public UserInterfaceApplication(IUserInterfaceComponentFactory uiFactory)
    {
        _uiFactory = uiFactory ?? throw new ArgumentNullException(nameof(uiFactory));
        _buttons = new List<IButton>();
        _textBoxes = new List<ITextBox>();
        _checkBoxes = new List<ICheckBox>();
    }

    public void CreateLoginForm()
    {
        // Create username field
        var usernameTextBox = _uiFactory.CreateTextBox();
        usernameTextBox.Render();
        usernameTextBox.SetText("Enter username");
        _textBoxes.Add(usernameTextBox);

        // Create password field
        var passwordTextBox = _uiFactory.CreateTextBox();
        passwordTextBox.Render();
        passwordTextBox.SetText("********");
        _textBoxes.Add(passwordTextBox);

        // Create login button
        var loginButton = _uiFactory.CreateButton();
        loginButton.Render();
        _buttons.Add(loginButton);

        Console.WriteLine("Login form created successfully");
    }
}
}