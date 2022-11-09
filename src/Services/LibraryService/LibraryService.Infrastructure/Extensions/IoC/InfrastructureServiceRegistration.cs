using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Application.Utilities.Configuration;
using LibraryService.Infrastructure.EventBus;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryService.Infrastructure.Extensions.IoC
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    BusType = EventBusType.RabbitMQ,
                    HostName = ConfigurationHelper.Config["RabbitMQ:HostName"],
                    Port = int.Parse(ConfigurationHelper.Config["RabbitMQ:Port"]),
                    DefaultExchangeName = ConfigurationHelper.Config["RabbitMQ:DefaultExchangeName"],
                    SubscriberClientName = "LibraryService"
            
                };
                return EventBusFactory.Create(config, sp);
            });
        }
    }
}
