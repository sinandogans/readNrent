using IdentityService.Application.Abstraction.Application.IntegrationEvent;
using IdentityService.Application.IntegrationEvents;

namespace IdentityService.Application.Abstraction.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Publish<TEvent>(IntegrationEvent @event) where TEvent : IntegrationEvent;
        void Subscribe<TEvent, TEventHandler>() where TEvent : IntegrationEvent where TEventHandler : IIntegrationEventHandler<TEvent>;
    }
}
