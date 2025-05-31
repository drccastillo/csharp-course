using PaymentApp.Interfaces;
using PaymentApp.Services;

namespace PaymentApp.Tests.Services;

public class TestPaymentRouter
{
    public sealed class DummyPayment : ICharger, IRefunder
    {
        public bool Charged { get; private set; }
        public bool Refunded { get; private set; }

        public void Charge(decimal amount, string reference) => Charged = true;
        public void Refund(decimal amount, string reference) => Refunded = true;
    }

    [Fact]
    public void TryRefund_ShouldSkip_WhenNotSupported()
    {
        var dummyPayment = new DummyPayment();
        var paymentRouter = new PaymentRouter(new[] { dummyPayment }, Array.Empty<IRefunder>());

        var result = paymentRouter.TryRefund("dummy", 100, "ref123");

        Assert.False(result);
    }

    [Fact]
    public void TryRefund_ShouldInvokeRefund_WhenSupported()
    {
        var dummyPayment = new DummyPayment();
        var paymentRouter = new PaymentRouter(new[] { dummyPayment }, new[] { dummyPayment });

        var result = paymentRouter.TryRefund("dummy", 100, "ref123");

        Assert.True(result);
        Assert.True(dummyPayment.Refunded);
    }
}