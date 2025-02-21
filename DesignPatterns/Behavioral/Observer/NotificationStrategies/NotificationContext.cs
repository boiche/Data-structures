namespace DesignPatterns.Behavioral.Observer.NotificationStrategies
{
    /// <summary>
    /// Enables loose-coupling logic for notification. Refer to Strategy design pattern
    /// </summary>
    public class NotificationContext
    {
        private readonly INotificationStrategy _notificationStrategy;
        public NotificationContext(INotificationStrategy notificationStrategy)
        {
            _notificationStrategy = notificationStrategy;
        }

        /// <summary>
        /// Executes notification method based on publisher's type
        /// </summary>
        public void Notify() => _notificationStrategy.Notify();
    }
}
