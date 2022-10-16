using IdentityService.Application.Abstraction.Application.IntegrationEvent;
using System.Text.Json;

namespace IdentityService.Application.IntegrationEvents.Users
{
    public class UserRegisteredIntegrationEventHandler : IIntegrationEventHandler<UserRegisteredIntegrationEvent>
    {
        public async Task Handle(UserRegisteredIntegrationEvent @event)
        {
            Console.WriteLine(JsonSerializer.Serialize(@event));
        }
    }
}
