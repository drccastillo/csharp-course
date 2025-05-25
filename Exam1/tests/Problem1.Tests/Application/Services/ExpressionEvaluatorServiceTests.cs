// File: tests/Problem1.Tests/Application/ExpressionEvaluatorServiceTests.cs
using Problem1.Application.Services;
using Problem1.Domain.Exceptions;
using Problem1.Domain.Interfaces;
using Problem1.Domain.Models;
using Problem1.Infrastructure.Repositories;

namespace Problem1.Tests.Application;

public class ExpressionEvaluatorServiceTests
{
    private readonly IUndoStackRepository _repository;
    private readonly IExpressionEvaluatorService _service;

    public ExpressionEvaluatorServiceTests()
    {
        _repository = new UndoStackRepository();
        _service = new ExpressionEvaluatorService(_repository);
    }

    [Fact]
    public void Evaluate_EmptyStack_ReturnsZero()
    {
        var result = _service.Evaluate();
        Assert.Equal(0, result);
    }

    [Fact]
    public void EnterNumber_AddsCorrectToken()
    {
        _service.EnterNumber(5);
        var result = _service.Evaluate();
        Assert.Equal(5, result);
    }

    [Fact]
    public void EnterOperator_InvalidOperator_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => _service.EnterOperator('%'));
    }

    [Fact]
    public void Evaluate_SimpleAddition()
    {
        _service.EnterNumber(3);
        _service.EnterOperator('+');
        _service.EnterNumber(7);
        var result = _service.Evaluate();
        Assert.Equal(10, result);
    }

    [Fact]
    public void Evaluate_OperatorPrecedence()
    {
        _service.EnterNumber(5);
        _service.EnterOperator('+');
        _service.EnterNumber(2);
        _service.EnterOperator('*');
        _service.EnterNumber(3);
        var result = _service.Evaluate();
        Assert.Equal(11, result);
    }

    [Fact]
    public void Evaluate_DivisionByZero_Throws()
    {
        _service.EnterNumber(4);
        _service.EnterOperator('/');
        _service.EnterNumber(0);
        Assert.Throws<InvalidExpressionException>(() => _service.Evaluate());
    }

    [Fact]
    public void Undo_RemovesLastToken()
    {
        _service.EnterNumber(9);
        _service.EnterOperator('*');
        _service.EnterNumber(2);
        _service.Undo();
        _service.Undo();
        var result = _service.Evaluate();
        Assert.Equal(9, result);
    }
    [Fact]
    public void Undo_incompleteExpression_Throws()
    {
        _service.EnterNumber(9);
        _service.EnterOperator('*');
        _service.EnterNumber(2);
        _service.Undo();
        Assert.Throws<InvalidExpressionException>(() => _service.Evaluate());
    }

    [Fact]
    public void Clear_RemovesAllTokens()
    {
        _service.EnterNumber(9);
        _service.EnterOperator('+');
        _service.EnterNumber(1);
        _service.Clear();
        var result = _service.Evaluate();
        Assert.Equal(0, result);
    }

    [Fact]
    public void Evaluate_IncompleteExpression_Throws()
    {
        _service.EnterNumber(1);
        _service.EnterOperator('+');
        Assert.Throws<InvalidExpressionException>(() => _service.Evaluate());
    }

    [Fact]
    public void Evaluate_UnknownOperator_Throws()
    {
        var repo = new UndoStackRepository();
        repo.Push(new NumberToken(1));
        repo.Push(new OperatorToken('#'));
        repo.Push(new NumberToken(2));
        var service = new ExpressionEvaluatorService(repo);

        Assert.Throws<InvalidExpressionException>(() => service.Evaluate());
    }
}
