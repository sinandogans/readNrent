using IdentityService.Application.Abstraction.Application.Security;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Application.Features.Users.DTOs;
using IdentityService.Application.Utilities.ResponseModel;
using IdentityService.Application.Utilities.Security.Hashing;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UserLoginCommand
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, IDataResponseModel<UserLoginResponseDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public UserLoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<IDataResponseModel<UserLoginResponseDTO>> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            HashingHelper.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash);
            var accessToken = _tokenHelper.CreateToken(user, await _userRepository.GetRoleClaims(user.Id));

            var responseData = new UserLoginResponseDTO() { Token = accessToken.Token, Expiration = accessToken.Expiration };
            return new SuccessDataResponseModel<UserLoginResponseDTO> { Message = "", Data = responseData };
        }
    }
}
