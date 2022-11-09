using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Application.IntegrationEvents.BookService.Books.BookAdded;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using Microsoft.Extensions.Hosting;

namespace LibraryService.Application.IntegrationEvents.BookService.EventListeners.Books.BookAdded;

public class BookAddedIntegrationEventListener : BackgroundService
{
    private readonly IEventBus _eventBus;

    public BookAddedIntegrationEventListener(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        _eventBus.Subscribe<BookAddedIntegrationEvent, BookAddedIntegrationEventHandler>();
        return Task.CompletedTask;
        //await Task.Delay(10000);
        //_eventBus.UnSubscribe<UserRegisteredIntegrationEvent, UserRegisteredIntegrationEventHandler>();
    }
}