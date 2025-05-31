using PaymentApp.Interfaces;

namespace PaymentApp.Services;

public class PaymentRouter(IEnumerable<ICharger> chargers, IEnumerable<IRefunder> refunders) : IPaymentRouter
{
  private readonly Dictionary<string, ICharger> _chargers = chargers.ToDictionary(c => c.GetType().Name[..^7].ToLower());
  private readonly Dictionary<string, IRefunder> _refunders = refunders.ToDictionary(r => r.GetType().Name[..^7].ToLower());

  public void Charge(string method, decimal amount, string reference)
  {
    PaymentValidation.ValidatePaymentArguments(method, amount, reference);
    if (!_chargers.ContainsKey(method))
      throw new ArgumentException($"Unknown payment method: {method}", nameof(method));
    _chargers[method].Charge(amount, reference);
  }

  public bool TryRefund(string method, decimal amount, string reference)
  {
    try
    {
      PaymentValidation.ValidatePaymentArguments(method, amount, reference);
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine($"Refund failed: {ex.Message}");
      return false;
    }
    if (TryGetRefunder(method, out var refunder))
    {
      ProcessRefund(refunder!, amount, reference); // null-forgiving operator to silence CS8604
      return true;
    }
    ShowRefundNotSupportedMessage(method);
    return false;
  }

  private bool TryGetRefunder(string method, out IRefunder? refunder)
  {
    return _refunders.TryGetValue(method, out refunder);
  }

  private static void ProcessRefund(IRefunder refunder, decimal amount, string reference)
  {
    refunder.Refund(amount, reference);
  }

  private static void ShowRefundNotSupportedMessage(string method)
  {
    Console.WriteLine($"Refund not supported for method {method}.");
  }
}