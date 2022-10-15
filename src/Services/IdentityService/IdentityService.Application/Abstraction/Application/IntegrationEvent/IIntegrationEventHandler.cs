namespace IdentityService.Application.Abstraction.Application.IntegrationEvent
{
    public interface IIntegrationEventHandler<TIntegrationEvent> where TIntegrationEvent : IntegrationEvents.IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}
