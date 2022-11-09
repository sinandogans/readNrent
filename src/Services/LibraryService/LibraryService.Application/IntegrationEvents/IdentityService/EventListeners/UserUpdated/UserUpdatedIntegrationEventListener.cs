using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using Microsoft.Extensions.Hosting;

namespace LibraryService.Application.IntegrationEvents.IdentityService.EventListeners.UserUpdated
{
    public class UserUpdatedIntegrationEventListener : BackgroundService
    {
        private readonly IEventBus _eventBus;
        public UserUpdatedIntegrationEventListener(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _eventBus.Subscribe<UserUpdatedIntegrationEvent, UserUpdatedIntegrationEventHandler>();
            return Task.CompletedTask;
        }
    }
}
