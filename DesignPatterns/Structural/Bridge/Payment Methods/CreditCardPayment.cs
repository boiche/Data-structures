using DesignPatterns.Structural.Bridge.Gateways;
using System;

namespace DesignPatterns.Structural.Bridge.PaymentMethods
{
    public class CreditCardPayment : PaymentMethod
    {
        public CreditCardPayment(IPaymentGateway gateway) : base(gateway) { }        
        public override void Pay(decimal amount, string currency)
        {
            Console.WriteLine("Paying with credit card");
            this.gateway.ProcessPayment(amount, currency);
        }
    }
}
