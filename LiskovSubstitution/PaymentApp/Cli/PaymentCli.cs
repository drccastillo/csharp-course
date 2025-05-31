using System.Text.Json;
using PaymentApp.Interfaces;
using PaymentApp.Models;

namespace PaymentApp.Cli;

public class PaymentCli(IPaymentRouter paymentRouter)
{
  private readonly IPaymentRouter _paymentRouter = paymentRouter;

    public void Run(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: PaymentCli <ordersJson>");
            return;
        }

        var json = args[0];
        List<Order>? orders;
        try
        {
            orders = JsonSerializer.Deserialize<List<Order>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (orders == null || orders.Count == 0)
            {
                Console.WriteLine("No orders to process.");
                return;
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("Invalid JSON input for orders.");
            return;
        }

        foreach (var order in orders)
        {
            _paymentRouter.Charge(order.Method, order.Amount, order.Reference);
        }

        Console.WriteLine("\n--- Cancel & refund second order ---");

        var cancelledOrder = orders[1];
        _paymentRouter.TryRefund(cancelledOrder.Method, cancelledOrder.Amount, cancelledOrder.Reference);
    }
}