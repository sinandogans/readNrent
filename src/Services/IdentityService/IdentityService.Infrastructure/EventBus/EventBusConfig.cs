namespace IdentityService.Infrastructure.EventBus
{
    public class EventBusConfig
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string DefaultExchangeName { get; set; }
    }
}
