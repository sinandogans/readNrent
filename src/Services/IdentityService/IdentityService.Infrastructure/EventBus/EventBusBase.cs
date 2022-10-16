using IdentityService.Application.Abstraction.Application.IntegrationEvent;
using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Application.IntegrationEvents;
using System.Text.Json;

namespace IdentityService.Infrastructure.EventBus
{
    public abstract class EventBusBase : IEventBus
    {
        private readonly EventBusConfig _config;

        public EventBusBase(EventBusConfig config)
        {
            _config = config;
        }

        public virtual string GetQueueName(string eventName)
        {
            return _config.SubscriberClientName + "_" + eventName;
        }

        public virtual string GetEventName(IntegrationEvent @event)
        {
            return @event.GetType().Name;
        }

        public async Task<bool> ProcessEvent<TEvent, TEventHandler>(string message)
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>
        {
            var typeOfEventHandler = typeof(TEventHandler);
            var eventHandler = (IIntegrationEventHandler<TEvent>)Activator.CreateInstance(typeOfEventHandler);
            var @event = JsonSerializer.Deserialize<TEvent>(message);
            await eventHandler.Handle(@event);

            return true;
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
