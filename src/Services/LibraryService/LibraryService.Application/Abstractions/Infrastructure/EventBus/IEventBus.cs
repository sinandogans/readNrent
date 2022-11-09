using LibraryService.Application.Abstractions.Application.IntegrationEvent;
using LibraryService.Application.IntegrationEvents;

namespace LibraryService.Application.Abstractions.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Publish<TEvent>(IntegrationEvent @event) where TEvent : IntegrationEvent;
        void Subscribe<TEvent, TEventHandler>() where TEvent : IntegrationEvent where TEventHandler : IIntegrationEventHandler<TEvent>;
        void UnSubscribe<TEvent, TEventHandler>() where TEvent : IntegrationEvent where TEventHandler : IIntegrationEventHandler<TEvent>;
    }
}
