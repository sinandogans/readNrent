using IdentityService.Application.Abstraction.Application.IntegrationEvent;
using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Application.IntegrationEvents;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IdentityService.Infrastructure.EventBus.RabbitMQ
{
    public class RabbitMQEventBus : IEventBus
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventBusConfig config;

        public RabbitMQEventBus(EventBusConfig config)
        {
            this.config = config;
            var factory = new ConnectionFactory()
            {
                HostName = config.HostName,
                Port = config.Port
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: config.DefaultExchangeName, "direct");
        }
        public void Publish<TEvent>(IntegrationEvent @event) where TEvent : IntegrationEvent
        {
            var eventName = @event.GetType().Name;

            var message = JsonSerializer.Serialize((TEvent)@event);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: config.DefaultExchangeName,
                routingKey: eventName,
                body: body
                );
        }

        public void Subscribe<TEvent, TEventHandler>() where TEvent : IntegrationEvent where TEventHandler : IIntegrationEventHandler<TEvent>
        {
            var eventName = typeof(TEvent).Name;
            _channel.QueueDeclare(
                queue: "IdentityService_" + eventName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            _channel.QueueBind(
                queue: "IdentityService_" + eventName,
                exchange: config.DefaultExchangeName,
                routingKey: eventName
                );

            var typeOfEventHandler = typeof(TEventHandler);
            var eventHandler = (IIntegrationEventHandler<TEvent>)Activator.CreateInstance(typeOfEventHandler);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var @event = JsonSerializer.Deserialize<TEvent>(message);

                eventHandler.Handle(@event);
            };

            _channel.BasicConsume(
                queue: "IdentityService_" + eventName,
                autoAck: false,
                consumer: consumer
                );

            Console.ReadLine();
        }
    }
}
