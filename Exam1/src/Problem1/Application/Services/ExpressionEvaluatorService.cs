using Problem1.Domain.Interfaces;
using Problem1.Domain.Models;
using Problem1.Domain.Exceptions;

namespace Problem1.Application.Services;

public class ExpressionEvaluatorService(IUndoStackRepository repository) : IExpressionEvaluatorService
{
    public void EnterNumber(double number) => repository.Push(new NumberToken(number));

    public void EnterOperator(char op)
    {
        if ("+-*/".Contains(op))
            repository.Push(new OperatorToken(op));
        else
            throw new ArgumentException("Invalid operator");
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
                           Precedence(operatorStack.Peek().Symbol) >= Precedence(op.Symbol))
                    {
                        outputQueue.Enqueue(operatorStack.Pop());
                    }
                    operatorStack.Push(op);
                    break;
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
                        '/' => right != 0 ? left / right : throw new InvalidExpressionException("Division by zero."),
                        _ => throw new InvalidExpressionException($"Unknown operator '{op.Symbol}'")
                    };
                    evaluationStack.Push(result);
                    break;
            }
        }

        if (evaluationStack.Count != 1)
            throw new InvalidExpressionException("The expression is incomplete or malformed.");

        return evaluationStack.Peek();
    }

    public void Undo() => repository.Pop();
    public void Clear() => repository.Clear();

    private static int Precedence(char op) => op switch
    {
        '+' or '-' => 1,
        '*' or '/' => 2,
        _ => throw new InvalidExpressionException($"Unknown operator: {op}")
    };
}
