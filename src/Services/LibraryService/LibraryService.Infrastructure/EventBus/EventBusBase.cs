using System.Text.Json;
using LibraryService.Application.Abstractions.Application.IntegrationEvent;
using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Application.IntegrationEvents;

namespace LibraryService.Infrastructure.EventBus
{
    public abstract class EventBusBase : IEventBus
    {
        protected readonly EventBusConfig _config;
        protected readonly IServiceProvider _serviceProvider;

        public EventBusBase(EventBusConfig config, IServiceProvider serviceProvider)
        {
            _config = config;
            _serviceProvider = serviceProvider;
        }

        public virtual string GetQueueName(string eventName)
        {
            return _config.SubscriberClientName + "_" + eventName;
        }

        public virtual string GetEventName(IntegrationEvent @event)
        {
            return @event.GetType().Name;
        }

        public async Task ProcessEvent<TEvent, TEventHandler>(string message)
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>
        {
            var eventHandler = (TEventHandler) _serviceProvider.GetService(typeof(TEventHandler));
            var @event = JsonSerializer.Deserialize<TEvent>(message);
            await eventHandler.Handle(@event);
        }

        public abstract void Publish<TEvent>(IntegrationEvent @event) where TEvent : IntegrationEvent;

        public abstract void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>;

        public abstract void UnSubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>;
    }
}