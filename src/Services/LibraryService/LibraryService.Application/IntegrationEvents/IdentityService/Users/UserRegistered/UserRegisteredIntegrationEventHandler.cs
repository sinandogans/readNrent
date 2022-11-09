using AutoMapper;
using LibraryService.Application.Abstractions.Application.IntegrationEvent;
using LibraryService.Domain.Abstraction.Repositories;
using LibraryService.Domain.AggregatesModel.UserAggregate;

namespace LibraryService.Application.IntegrationEvents.IdentityService.Users.UserRegistered
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
