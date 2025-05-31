namespace PaymentApp.Services;

public static class PaymentValidation
{
    public static void ValidatePaymentArguments(string method, decimal amount, string reference)
    {
        if (string.IsNullOrWhiteSpace(method))
            throw new ArgumentException("Payment method must not be empty.", nameof(method));
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive.", nameof(amount));
        if (string.IsNullOrWhiteSpace(reference))
            throw new ArgumentException("Reference must not be empty.", nameof(reference));
    }
}
