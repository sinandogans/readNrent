using BookService.Application.Abstraction.Infrastructure.EventBus;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using Microsoft.Extensions.Hosting;

namespace BookService.Application.IntegrationEvents.IdentityService.EventListeners.UserUpdated
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
