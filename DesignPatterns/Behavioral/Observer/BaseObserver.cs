using System;
using System.Linq;

namespace DesignPatterns.Behavioral.Observer
{
    public abstract class BaseObserver
    {
        protected delegate void UpdateEventHandler(object source, UpdateEventArgs e);
        protected event UpdateEventHandler OnUpdate;

        public BaseObserver()
        {
            OnUpdate += (source, e) =>
            {
                e.notificationContext.Notify();
            };
        }

        public virtual void Update(BasePublisher publisher)
        {
            var eventArgs = new UpdateEventArgs(publisher);
            foreach (var item in publisher.GetType().GetProperties().Where(x => x.IsDefined(typeof(Observable), false)))
            {
                Console.WriteLine(item.GetValue(publisher).ToString());
            }

            OnUpdate.Invoke(this, eventArgs);
        }
    }
}
