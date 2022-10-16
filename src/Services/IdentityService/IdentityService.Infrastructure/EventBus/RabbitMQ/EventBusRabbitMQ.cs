using IdentityService.Application.Abstraction.Application.IntegrationEvent;
using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Application.IntegrationEvents;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace IdentityService.Infrastructure.EventBus.RabbitMQ
{
    public class EventBusRabbitMQ : EventBusBase, IEventBus
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly EventBusConfig _config;
        private Dictionary<string, string> _eventName_ConsumerTag;

        public EventBusRabbitMQ(EventBusConfig config) : base(config)
        {
            this._config = config;
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
            var message = JsonSerializer.Serialize((TEvent)@event);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: _config.DefaultExchangeName,
                routingKey: GetEventName(@event),
                body: body);
        }

        public override void Subscribe<TEvent, TEventHandler>()
        {
            var eventName = typeof(TEvent).Name;

            _channel.QueueDeclare(queue: GetQueueName(eventName), durable: true, exclusive: false, autoDelete: false, arguments: null);

            _channel.QueueBind(queue: GetQueueName(eventName), exchange: _config.DefaultExchangeName, routingKey: eventName);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received<TEvent, TEventHandler>;
            _channel.BasicConsume(queue: GetQueueName(eventName), autoAck: false, consumer: consumer);
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
            var isSuccess = await ProcessEvent<TEvent, TEventHandler>(message);
            if (isSuccess)
                _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}
