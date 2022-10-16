using AutoMapper;
using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Application.IntegrationEvents.Users;
using IdentityService.Application.Utilities.ResponseModel;
using IdentityService.Application.Utilities.Security.Hashing;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UserRegisterCommand
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, IResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        public UserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IEventBus eventBus)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        public async Task<IResponseModel> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {

            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            var userToAdd = _mapper.Map<User>(request);
            userToAdd.Id = Guid.NewGuid();
            userToAdd.PasswordSalt = passwordSalt;
            userToAdd.PasswordHash = passwordHash;

            await _userRepository.Add(userToAdd);
            var userRegisteredEvent = _mapper.Map<UserRegisteredIntegrationEvent>(userToAdd);
            _eventBus.Publish<UserRegisteredIntegrationEvent>(userRegisteredEvent);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
