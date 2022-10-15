using IdentityService.Application.Abstraction.Application.IntegrationEvent;

namespace IdentityService.Application.IntegrationEvents.Users
{
    public class UserRegisteredIntegrationEventHandler : IIntegrationEventHandler<UserRegisteredIntegrationEvent>
    {
        public async Task Handle(UserRegisteredIntegrationEvent @event)
        {
            Console.WriteLine("saaaaaa");
        }
    }
}
