using BookService.Application.Abstraction.Application.IntegrationEvent;
using BookService.Application.IntegrationEvents;

namespace BookService.Application.Abstraction.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Publish<TEvent>(IntegrationEvent @event) where TEvent : IntegrationEvent;
        void Subscribe<TEvent, TEventHandler>() where TEvent : IntegrationEvent where TEventHandler : IIntegrationEventHandler<TEvent>;
        void UnSubscribe<TEvent, TEventHandler>() where TEvent : IntegrationEvent where TEventHandler : IIntegrationEventHandler<TEvent>;
    }
}
