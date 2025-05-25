namespace Problem1.Domain.Models;

public abstract record Token;
public record NumberToken(double Value) : Token;
public record OperatorToken(char Symbol) : Token;