namespace Problem1.Application.Services;

public interface IExpressionEvaluatorService
{
    void EnterNumber(double number);
    void EnterOperator(char op);
    double Evaluate();
    void Undo();
    void Clear();
}
