// File: Application/Services/ExpressionEvaluatorService.cs
using Problem1.Domain.Interfaces;
using Problem1.Domain.Models;
using Problem1.Domain.Exceptions;

namespace Problem1.Application.Services;

public class ExpressionEvaluatorService(
    IUndoStackRepository repository,
    IExpressionValidator validator) : IExpressionEvaluatorService
{
    private static readonly Dictionary<char, int> Precedence = new()
    {
        ['+'] = 1,
        ['-'] = 1,
        ['*'] = 2,
        ['/'] = 2
    };

    public void EnterNumber(double number)
    {
        validator.ValidateNumber(number);
        repository.Push(new NumberToken(number));
    }

    public void EnterOperator(char op)
    {
        validator.ValidateOperator(op);
        repository.Push(new OperatorToken(op));
    }

    public double Evaluate()
    {
        var tokens = repository.GetStack();
        if (tokens.Count == 0) return 0;

        var outputQueue = new Queue<Token>();
        var operatorStack = new Stack<OperatorToken>();

        foreach (var token in tokens)
        {
            switch (token)
            {
                case NumberToken number:
                    outputQueue.Enqueue(number);
                    break;

                case OperatorToken op:
                    while (operatorStack.Count > 0 &&
                           Precedence[operatorStack.Peek().Symbol] >= Precedence[op.Symbol])
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(op);
                    break;

                default:
                    throw new InvalidExpressionException("Unrecognized token type");
            }
        }

        while (operatorStack.Count > 0)
        {
            outputQueue.Enqueue(operatorStack.Pop());
        }

        var evaluationStack = new Stack<double>();
        foreach (var token in outputQueue)
        {
            switch (token)
            {
                case NumberToken number:
                    evaluationStack.Push(number.Value);
                    break;

                case OperatorToken op:
                    if (evaluationStack.Count < 2)
                        throw new InvalidExpressionException($"Insufficient operands for operator '{op.Symbol}'.");

                    var right = evaluationStack.Pop();
                    var left = evaluationStack.Pop();
                    var result = op.Symbol switch
                    {
                        '+' => left + right,
                        '-' => left - right,
                        '*' => left * right,
                        '/' when right != 0 => left / right,
                        '/' => throw new InvalidExpressionException("Division by zero."),
                        _ => throw new InvalidExpressionException($"Unknown operator '{op.Symbol}'")
                    };
                    evaluationStack.Push(result);
                    break;

                default:
                    throw new InvalidExpressionException("Unexpected token in evaluation queue");
            }
        }

        if (evaluationStack.Count != 1)
            throw new InvalidExpressionException("The expression is incomplete or malformed.");

        return evaluationStack.Peek();
    }

    public void Undo() => repository.Pop();
    public void Clear() => repository.Clear();
} 
