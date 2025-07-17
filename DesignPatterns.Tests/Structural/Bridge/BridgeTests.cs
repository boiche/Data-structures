using DesignPatterns.Structural.Bridge;
using DesignPatterns.Structural.Bridge.Gateways;
using DesignPatterns.Structural.Bridge.PaymentMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Tests.Structural.Bridge
{
    [TestClass]
    public partial class BridgeTests
    {
        [TestMethod]
        public void Bridge_Demo()
        {
            IPaymentGateway stripe = new StripeGateway();
            IPaymentGateway paypal = new PayPalGateway();

            PaymentMethod creditCard = new CreditCardPayment(stripe);
            creditCard.Pay(100, "USD");

            PaymentMethod bankTransfer = new BankTransferPayment(paypal);
            bankTransfer.Pay(300, "JPY");
        }
    }
}
