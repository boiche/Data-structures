using DesignPatterns.Structural.Bridge.Gateways;

namespace DesignPatterns.Structural.Bridge
{
    public abstract class PaymentMethod
    {
        protected IPaymentGateway gateway;

        protected PaymentMethod(IPaymentGateway gateway)
        {
            this.gateway = gateway;
        }

        public abstract void Pay(decimal amount, string currency);
    }
}
