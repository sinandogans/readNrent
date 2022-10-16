using AutoMapper;
using IdentityService.Application.Abstraction.Infrastructure.EventBus;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Application.IntegrationEvents.IdentityService.Users.UserUpdated;
using IdentityService.Application.Utilities.ResponseModel;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandRequest : IRequest<IResponseModel>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, IResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventBus _eventBus;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IEventBus eventBus, IMapper mapper)
        {
            _userRepository = userRepository;
            _eventBus = eventBus;
            _mapper = mapper;
        }

        public async Task<IResponseModel> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _userRepository.GetById(request.Id);

            if (request.FirstName != String.Empty)
                userToUpdate.FirstName = request.FirstName;
            if (request.LastName != String.Empty)
                userToUpdate.LastName = request.LastName;
            if (request.UserName != String.Empty)
                userToUpdate.UserName = request.UserName;

            await _userRepository.Update(userToUpdate);

            var eventToPublish = _mapper.Map<UserUpdatedIntegrationEvent>(userToUpdate);
            _eventBus.Publish<UserUpdatedIntegrationEvent>(eventToPublish);

            return new SuccessResponseModel() { Message = "" };
        }
    }
}
