using LibraryService.Application.Abstractions.Application.IntegrationEvent;
using LibraryService.Domain.Abstraction.Repositories;

namespace LibraryService.Application.IntegrationEvents.IdentityService.Users.UserUpdated
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
            userToUpdate.UserName = @event.UserName;

            await _userRepository.Update(userToUpdate);
        }
    }
}