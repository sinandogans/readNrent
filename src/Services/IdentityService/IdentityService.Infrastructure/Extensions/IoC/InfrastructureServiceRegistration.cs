using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Application.Utilities.Configuration;
using IdentityService.Infrastructure.EventBus;
using IdentityService.Infrastructure.EventBus.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Infrastructure.Extensions.IoC
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    HostName = ConfigurationHelper.Config["RabbitMQ:HostName"],
                    Port = int.Parse(ConfigurationHelper.Config["RabbitMQ:Port"]),
                    DefaultExchangeName = ConfigurationHelper.Config["RabbitMQ:DefaultExchangeName"],
                    SubscriberClientName = "IdentityService"
                };
                return new EventBusRabbitMQ(config, sp);
            }
            );
        }
    }
}
