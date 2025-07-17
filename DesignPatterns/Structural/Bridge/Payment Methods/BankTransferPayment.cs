using DesignPatterns.Structural.Bridge.Gateways;
using System;

namespace DesignPatterns.Structural.Bridge.Payment_Methods
{
    public class BankTransferPayment : PaymentMethod
    {
        public BankTransferPayment(IPaymentGateway gateway) : base(gateway) { }        
        public override void Pay(decimal amount, string currency)
        {
            Console.WriteLine("Bank transfer payment");
            gateway.ProcessPayment(amount, currency);
        }
    }
}
