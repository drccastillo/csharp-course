namespace PaymentApp.Interfaces;

/// <summary>
/// Routes payment and refund requests to the appropriate payment service.
/// Implementations must validate input arguments (method, amount, reference) and throw
/// ArgumentException or return false for invalid data.
/// </summary>
public interface IPaymentRouter
{
    /// <summary>
    /// Charges the specified amount using the given payment method and reference.
    /// Throws ArgumentException if arguments are invalid.
    /// </summary>
    void Charge(string method, decimal amount, string reference);

    /// <summary>
    /// Attempts to refund the specified amount using the given payment method and reference.
    /// Returns false if refund is not possible or arguments are invalid.
    /// </summary>
    bool TryRefund(string method, decimal amount, string reference);
}