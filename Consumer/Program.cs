using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory()
{ 
    HostName = "localhost"
};
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("Queue", false, false, false, null);
var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"Received: {message}");
};
channel.BasicConsume("Queue", true, consumer);

Console.ReadKey();