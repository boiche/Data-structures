using System;

namespace DesignPatterns.Structural.Bridge.Gateways
{
    public class StripeGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine("Stripe payment");
        }
    }
}
