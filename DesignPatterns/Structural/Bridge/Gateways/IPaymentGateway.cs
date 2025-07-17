namespace DesignPatterns.Structural.Bridge.Gateways
{
    public interface IPaymentGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        void ProcessPayment(decimal amount, string currency);        
    }
}
