using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Infrastructure.EventBus.RabbitMQ;

namespace IdentityService.Infrastructure.EventBus
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            return config.BusType switch
            {
                EventBusType.RabbitMQ => new EventBusRabbitMQ(config, serviceProvider)
            };
        }
    }
}
