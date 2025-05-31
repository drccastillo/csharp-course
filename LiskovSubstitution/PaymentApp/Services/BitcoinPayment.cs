using PaymentApp.Interfaces;
using PaymentApp.Services;

namespace PaymentApp.Services;

public class BitcoinPayment : ICharger
{
  public void Charge(decimal amount, string reference)
  {
    PaymentValidation.ValidatePaymentArguments("bitcoin", amount, reference);
    Console.WriteLine($"Charged {amount:C} to bitcoin wallet with reference {reference}.");
  }
}