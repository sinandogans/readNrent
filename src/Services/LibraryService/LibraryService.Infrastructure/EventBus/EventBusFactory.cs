using LibraryService.Application.Abstractions.Infrastructure.EventBus;
using LibraryService.Infrastructure.EventBus.RabbitMQ;

namespace LibraryService.Infrastructure.EventBus
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
