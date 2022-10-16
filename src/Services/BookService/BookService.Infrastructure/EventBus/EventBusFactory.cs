using BookService.Application.Abstraction.Infrastructure.EventBus;
using BookService.Infrastructure.EventBus.RabbitMQ;

namespace BookService.Infrastructure.EventBus
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
