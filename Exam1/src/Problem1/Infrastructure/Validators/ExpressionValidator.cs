using Problem1.Domain.Exceptions;
using Problem1.Domain.Interfaces;

namespace Problem1.Infrastructure.Validators;

public class ExpressionValidator : IExpressionValidator
{
    private static readonly HashSet<char> ValidOperators = ['+', '-', '*', '/'];

    public void ValidateNumber(double number)
    {
        if (double.IsNaN(number) || double.IsInfinity(number))
            throw new InvalidExpressionException("Invalid number: must be a finite numeric value.");
    }

    public void ValidateOperator(char op)
    {
        if (!ValidOperators.Contains(op))
            throw new InvalidExpressionException($"Unsupported operator: '{op}'");
    }
}