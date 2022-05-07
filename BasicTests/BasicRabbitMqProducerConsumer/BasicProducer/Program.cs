
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

SendMessage();

static void SendMessage()
{

    var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

    using (var connection = connectionFactory.CreateConnection())
    {
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BasicQueueTest", false, false, false, null);

            var message = "Message to RabbitMQ";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "BasicQueueTest", null, body);
            Console.WriteLine("Send message {0}...", message);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());

                Console.WriteLine("Received message {0}...", content);
                channel.BasicAck(ea.DeliveryTag, false);
            };
            channel.BasicConsume("BasicQueueTest", false, consumer);

        }

    }
    Console.WriteLine("Press [enter] to exit the Sender App");
    Console.ReadLine();
}