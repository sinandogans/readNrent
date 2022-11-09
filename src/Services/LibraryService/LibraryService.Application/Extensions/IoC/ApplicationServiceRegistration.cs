using System.Reflection;
using LibraryService.Application.IntegrationEvents.BookService.Books.BookAdded;
using LibraryService.Application.IntegrationEvents.BookService.EventListeners.Books.BookAdded;
using LibraryService.Application.IntegrationEvents.IdentityService.EventListeners.UserRegistered;
using LibraryService.Application.IntegrationEvents.IdentityService.EventListeners.UserUpdated;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using LibraryService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Application.Extensions.IoC
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddHostedService<UserRegisteredIntegrationEventListener>();
            services.AddSingleton<UserRegisteredIntegrationEventHandler>();
            //services.AddHostedService<UserUpdatedIntegrationEventListener>();
            //services.AddSingleton<UserUpdatedIntegrationEventHandler>();
            services.AddHostedService<BookAddedIntegrationEventListener>();
            services.AddSingleton<BookAddedIntegrationEventHandler>();
        }
    }
}