namespace LibraryService.Infrastructure.EventBus
{
    public class EventBusConfig
    {
        public EventBusType BusType { get; set; } = EventBusType.RabbitMQ;
        public int MyProperty { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string DefaultExchangeName { get; set; }
        public string SubscriberClientName { get; set; }
    }

    public enum EventBusType
    {
        RabbitMQ,
        Kafka,
        AzureServiceBus
    }
}
