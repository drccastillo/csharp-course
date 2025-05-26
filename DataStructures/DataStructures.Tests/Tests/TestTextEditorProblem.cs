using DataStructures;

namespace DataStructures.Tests;

public class TestTextEditorProblem
{
    [Fact]
    public void Type_AddsCharactersToText()
    {
        var editor = new TextEditorProblem();
        editor.Type('A');
        editor.Type('B');
        editor.Type('C');
        Assert.Equal("ABC", editor.GetText());
    }

    [Fact]
    public void Undo_RemovesLastCharacter()
    {
        var editor = new TextEditorProblem();
        editor.Type('X');
        editor.Type('Y');
        editor.Undo();
        Assert.Equal("X", editor.GetText());
    }

    [Fact]
    public void Undo_OnEmptyText_DoesNothing()
    {
        var editor = new TextEditorProblem();
        editor.Undo();
        Assert.Equal("", editor.GetText());
    }

    [Fact]
    public void GetText_ReturnsEmptyString_WhenNoInput()
    {
        var editor = new TextEditorProblem();
        Assert.Equal("", editor.GetText());
    }
}
