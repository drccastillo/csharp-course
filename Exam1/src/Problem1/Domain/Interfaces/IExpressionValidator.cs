namespace Problem1.Domain.Interfaces;

public interface IExpressionValidator
{
    void ValidateNumber(double number);
    void ValidateOperator(char op);
} 
