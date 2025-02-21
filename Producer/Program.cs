using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost"
};
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.QueueDeclare("Queue", false, false, false, null);

string message = "This is a message";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(string.Empty, "Queue", null, body);

Console.WriteLine("Sent");