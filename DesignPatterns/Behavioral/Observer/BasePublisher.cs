using DesignPatterns.Behavioral.Observer.NotificationStrategies;
using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer
{
    public abstract class BasePublisher
    {
        protected enum PublisherTypes
        {
            Message,
            Request
        }

        protected List<BaseObserver> _subscribers;
        protected PublisherTypes publisherType;

        protected delegate void NotificationEventHandler(object source, EventArgs e);
        protected event NotificationEventHandler OnNotification;

        public BasePublisher()
        {
            _subscribers = new List<BaseObserver>();
            OnNotification += (source, e) => NotifyAll();
        }

        public INotificationStrategy GetNotifier()
        {
            return publisherType switch
            {
                PublisherTypes.Message => new MessageStrategy(),
                PublisherTypes.Request => new RequestStrategy(),
                _ => throw new InvalidOperationException(),
            };
        }

        public virtual void Notify(BaseObserver observer) => observer.Update(this);

        public virtual void NotifyAll() => _subscribers.ForEach(x => Notify(x));

        public virtual void Subscribe(BaseObserver observer) => _subscribers.Add(observer);

        public virtual void Unsubscribe(BaseObserver observer) => _subscribers.Remove(observer);

        /// <summary>
        /// Calls registered delegates responsible for notification all registered subscribers
        /// </summary>
        protected void InvokeNotification() => OnNotification.Invoke(this, EventArgs.Empty);
    }
}
