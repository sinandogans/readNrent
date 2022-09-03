using AutoMapper;
using IdentityService.Application.Abstraction.Application.Security;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Application.Security.Hashing;
using IdentityService.Domain.Entities;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UserRegisterCommand
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommandRequest, UserRegisterCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        public UserRegisterCommandHandler(IUserWriteRepository userWriteRepository, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userWriteRepository = userWriteRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public async Task<UserRegisterCommandResponse> Handle(UserRegisterCommandRequest request, CancellationToken cancellationToken)
        {
            HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            await _userWriteRepository.Add(user);
            var response = _mapper.Map<UserRegisterCommandResponse>(user);
            return response;
        }
    }
}
