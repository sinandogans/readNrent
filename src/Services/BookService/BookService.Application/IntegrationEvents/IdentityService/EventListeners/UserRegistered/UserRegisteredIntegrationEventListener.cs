using BookService.Application.Abstraction.Infrastructure.EventBus;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using Microsoft.Extensions.Hosting;

namespace BookService.Application.IntegrationEvents.IdentityService.EventListeners.UserRegistered
{
    public class UserRegisteredIntegrationEventListener : BackgroundService
    {
        private readonly IEventBus _eventBus;

        public UserRegisteredIntegrationEventListener(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _eventBus.Subscribe<UserRegisteredIntegrationEvent, UserRegisteredIntegrationEventHandler>();
            //await Task.Delay(10000);
            //_eventBus.UnSubscribe<UserRegisteredIntegrationEvent, UserRegisteredIntegrationEventHandler>();
            //return Task.CompletedTask;
        }
    }
}
