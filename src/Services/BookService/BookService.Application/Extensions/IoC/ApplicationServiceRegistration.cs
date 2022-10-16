using BookService.Application.IntegrationEvents.IdentityService.EventListeners.UserRegistered;
using BookService.Application.IntegrationEvents.IdentityService.EventListeners.UserUpdated;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserRegistered;
using BookService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookService.Application.Extensions.IoC
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddHostedService<UserRegisteredIntegrationEventListener>();
            services.AddHostedService<UserUpdatedIntegrationEventListener>();
            services.AddSingleton<UserRegisteredIntegrationEventHandler>();
            services.AddSingleton<UserUpdatedIntegrationEventHandler>();
        }
    }
}
