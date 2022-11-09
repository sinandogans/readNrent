using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using Microsoft.Extensions.Hosting;

namespace LibraryService.Application.IntegrationEvents.IdentityService.EventListeners.UserRegistered
{
    public class UserRegisteredIntegrationEventListener : BackgroundService
    {
        private readonly IEventBus _eventBus;

        public UserRegisteredIntegrationEventListener(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _eventBus.Subscribe<UserRegisteredIntegrationEvent, UserRegisteredIntegrationEventHandler>();
            return Task.CompletedTask;
            //await Task.Delay(10000);
            //_eventBus.UnSubscribe<UserRegisteredIntegrationEvent, UserRegisteredIntegrationEventHandler>();
        }
    }
}