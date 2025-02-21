using RegularExpressionDataGenerator;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Provides message notification API. Let's assume external API generates messages (i.e. SignalR chat app).
    /// This class is responsible for providing information about each new message to all concerned users. 
    /// Further business logic for notification is supposed to be implemented
    /// </summary>
    public class MessagePublisher : BasePublisher
    {
        private readonly RegExpDataGenerator _sourceNameGenerator;
        private readonly RegExpDataGenerator _URLGenerator;

        [Observable]
        public string NewestMessage { get; set; }
        [Observable]
        public Source Source { get; set; }


        private List<string> OldMessages { get; set; }

        public MessagePublisher() : base()
        {
            publisherType = PublisherTypes.Message;
            _sourceNameGenerator = new RegExpDataGenerator($"[A-Z]\\w{{2, 10}}");
            _URLGenerator = new RegExpDataGenerator($"https?://\\w{{2, 10}}\\.(com|bg|net|org)");            
        }

        public void PublishMessage(string message, bool newSource = true) //new message from external API has invoked this notification method
        {
            if (!string.IsNullOrEmpty(NewestMessage)) OldMessages.Add(NewestMessage);
            if (newSource)
            {
                Source = new Source()
                {
                    Name = _sourceNameGenerator.Next(),
                    URL = _URLGenerator.Next(),
                };
            }
            NewestMessage = message;
            InvokeNotification();
        }
    }
}
