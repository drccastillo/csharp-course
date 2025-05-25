namespace Problem1.Domain.Interfaces;

public interface IInputValidator
{
    bool IsNumber(string token, out double value);
    bool IsOperator(string token, out char op);
    bool IsValidToken(string token);
}
