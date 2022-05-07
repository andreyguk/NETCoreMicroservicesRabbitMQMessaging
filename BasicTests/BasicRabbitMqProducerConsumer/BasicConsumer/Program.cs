
using RabbitMQ.Client;

using RabbitMQ.Client.Events;
using System.Text;

GetMessage();

void GetMessage()
{
    var factory = new ConnectionFactory() { HostName = "localhost" };

    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
        channel.QueueDeclare("BasicQueueTest", false, false, false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (sender, args) =>
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine("Received message {0}...", message);
        };

        channel.BasicConsume("BasicQueueTest", true, consumer);
        Console.WriteLine("Press [enter] to exit the Consumer App");
        Console.ReadLine();
    }   
}

