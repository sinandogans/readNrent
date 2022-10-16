using BookService.Application.Abstraction.Infrastructure.EventBus;
using BookService.Application.Abstraction.Infrastructure.FileOperations;
using BookService.Application.Utilities.Configuration;
using BookService.Infrastructure.EventBus;
using BookService.Infrastructure.EventBus.RabbitMQ;
using BookService.Infrastructure.FileOperations;
using Microsoft.Extensions.DependencyInjection;

namespace BookService.Infrastructure.Extensions.IoC
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<IFileHelper, FileHelper>();
            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    HostName = ConfigurationHelper.Config["RabbitMQ:HostName"],
                    Port = int.Parse(ConfigurationHelper.Config["RabbitMQ:Port"]),
                    DefaultExchangeName = ConfigurationHelper.Config["RabbitMQ:DefaultExchangeName"],
                    SubscriberClientName = "BookService"
                };
                return new EventBusRabbitMQ(config, sp);
            });
        }
    }
}
