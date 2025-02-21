namespace DesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Provides request notification API. Let's assume external API generates requests.
    /// This class is responsible for providing information about each new request to all concerned users. 
    /// Further business logic for notification is supposed to be implemented
    /// </summary>
    public class RequestPublisher : BasePublisher
    {
        [Observable]
        public Request Request { get; set; }

        public RequestPublisher() : base()
        {
            publisherType = PublisherTypes.Request;
        }

        public void PublishRequest(Request request) //new message from external API has invoked this notification method
        {
            Request = request;
            InvokeNotification();
        }
    }
}
