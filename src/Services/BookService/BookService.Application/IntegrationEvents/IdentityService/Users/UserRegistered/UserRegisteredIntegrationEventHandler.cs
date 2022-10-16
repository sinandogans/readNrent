using AutoMapper;
using BookService.Application.Abstraction.Application.IntegrationEvent;
using BookService.Application.Abstraction.Persistence.UserRepository;
using BookService.Domain.Entities;

namespace BookService.Application.IntegrationEvents.IdentityService.Users.UserRegistered
{
    public class UserRegisteredIntegrationEventHandler : IIntegrationEventHandler<UserRegisteredIntegrationEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserRegisteredIntegrationEventHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(UserRegisteredIntegrationEvent @event)
        {
            var userToAdd = _mapper.Map<User>(@event);
            await _userRepository.Add(userToAdd);
        }
    }
}
