namespace DesignPatterns.Behavioral.Observer.NotificationStrategies
{
    public interface INotificationStrategy
    {
        /// <summary>
        /// Business logic based on specific notification BasePublisher 
        /// </summary>
        public void Notify();
    }
}