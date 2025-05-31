using PaymentApp.Interfaces;
using PaymentApp.Services;

namespace PaymentApp.Services;

public class PayPalPayment : ICharger, IRefunder
{
  public void Charge(decimal amount, string reference)
  {
    PaymentValidation.ValidatePaymentArguments("paypal", amount, reference);
    Console.WriteLine($"Charged {amount:C} to PayPal account with reference {reference}.");
  }

  public void Refund(decimal amount, string reference)
  {
    PaymentValidation.ValidatePaymentArguments("paypal", amount, reference);
    Console.WriteLine($"Refunded {amount:C} to PayPal account with reference {reference}.");
  }
}