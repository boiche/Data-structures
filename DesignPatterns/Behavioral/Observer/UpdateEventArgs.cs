using DesignPatterns.Behavioral.Observer.NotificationStrategies;
using System;

namespace DesignPatterns.Behavioral.Observer
{
    public class UpdateEventArgs : EventArgs
    {
        public readonly NotificationContext notificationContext;
        public UpdateEventArgs(BasePublisher publisher)
        {
            notificationContext = new NotificationContext(publisher.GetNotifier());
        }
    }
}
