using BookService.Application.Abstraction.Application.IntegrationEvent;
using BookService.Application.Abstraction.Persistence.UserRepository;

namespace BookService.Application.IntegrationEvents.IdentityService.Users.UserUpdated
{
    public class UserUpdatedIntegrationEventHandler : IIntegrationEventHandler<UserUpdatedIntegrationEvent>
    {
        private readonly IUserRepository _userRepository;

        public UserUpdatedIntegrationEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Handle(UserUpdatedIntegrationEvent @event)
        {
            var userToUpdate = await _userRepository.GetById(@event.UserId);
            userToUpdate.FirstName = @event.FirstName;
            userToUpdate.LastName = @event.LastName;
            userToUpdate.Username = @event.UserName;

            await _userRepository.Update(userToUpdate);
        }
    }
}
