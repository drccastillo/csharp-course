using Problem4.Domain.Models;
using Problem4.Domain.Interfaces;

namespace Problem4.Application.Services;

public class OrderProcessor(
    IOrderValidator validator,
    IOrderFormatter formatter,
    IOrderLogger logger
)
{
    public void Process()
    {
        var orders = new List<Order>
        {
            new("A100", 2, 15.50m),
            new("B200", 1, 99.99m),
            new("C300", 5, 7.25m),
            new("D400", 0, 12.00m),
            new("E500", 2, 0.00m)
        };

        foreach (var order in orders)
        {
            if (!validator.IsValid(order))
            {
                foreach (var msg in validator.GetValidationMessages(order))
                    logger.Log(msg);
                continue;
            }

            logger.Log(formatter.Format(order));
        }

        logger.Flush();
    }
}