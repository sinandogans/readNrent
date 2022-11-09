namespace LibraryService.Application.Abstractions.Application.IntegrationEvent
{
    public interface IIntegrationEventHandler<TIntegrationEvent> where TIntegrationEvent : IntegrationEvents.IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}
