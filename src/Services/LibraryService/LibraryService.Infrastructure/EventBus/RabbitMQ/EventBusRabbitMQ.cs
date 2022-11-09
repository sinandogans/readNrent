using System.Text;
using System.Text.Json;
using LibraryService.Application.Abstractions.Application.IntegrationEvent;
using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Application.IntegrationEvents;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LibraryService.Infrastructure.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : EventBusBase, IEventBus
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private Dictionary<string, string> _eventName_ConsumerTag;

        public EventBusRabbitMQ(EventBusConfig config, IServiceProvider serviceProvider) : base(config, serviceProvider)
        {
            _eventName_ConsumerTag = new Dictionary<string, string>();
            var factory = new ConnectionFactory()
            {
                HostName = config.HostName,
                Port = config.Port
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: config.DefaultExchangeName, "direct", durable: true, autoDelete: false);
        }

        public override void Publish<TEvent>(IntegrationEvent @event)
        {
            var message = JsonSerializer.Serialize((TEvent) @event);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: _config.DefaultExchangeName,
                routingKey: GetEventName(@event),
                body: body);
        }

        public override void Subscribe<TEvent, TEventHandler>()
        {
            var eventName = typeof(TEvent).Name;
            var queueName = GetQueueName(eventName);

            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false,
                arguments: null);
            _channel.QueueBind(queue: queueName, exchange: _config.DefaultExchangeName, routingKey: eventName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received<TEvent, TEventHandler>;
            _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }

        public override void UnSubscribe<TEvent, TEventHandler>()
        {
            var consumerTag = _eventName_ConsumerTag.GetValueOrDefault(typeof(TEvent).Name);
            if (consumerTag != null)
            {
                _channel.BasicCancel(consumerTag);
                _eventName_ConsumerTag.Remove(typeof(TEvent).Name);
            }
        }

        private async void Consumer_Received<TEvent, TEventHandler>(object? sender, BasicDeliverEventArgs e)
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>
        {
            if (!_eventName_ConsumerTag.ContainsKey(typeof(TEvent).Name))
                _eventName_ConsumerTag.Add(typeof(TEvent).Name, e.ConsumerTag);

            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            await ProcessEvent<TEvent, TEventHandler>(message);
            _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}