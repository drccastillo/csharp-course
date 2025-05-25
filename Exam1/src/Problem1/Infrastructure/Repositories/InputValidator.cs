using Problem1.Domain.Interfaces;

namespace Problem1.Infrastructure.Validators;

public class InputValidator : IInputValidator
{
    public bool IsNumber(string token, out double value)
        => double.TryParse(token, out value);

    public bool IsOperator(string token, out char op)
    {
        op = default;
        if (token.Length == 1 && "+-*/".Contains(token[0]))
        {
            op = token[0];
            return true;
        }
        return false;
    }

    public bool IsValidToken(string token)
        => IsNumber(token, out _) || IsOperator(token, out _);
}
