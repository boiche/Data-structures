using System;

namespace DesignPatterns.Structural.Bridge.Gateways
{
    public class PayPalGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine("PayPal payment");
        }
    }
}
