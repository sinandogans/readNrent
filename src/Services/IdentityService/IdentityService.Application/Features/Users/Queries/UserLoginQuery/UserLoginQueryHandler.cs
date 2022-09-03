using IdentityService.Application.Abstraction.Application.Security;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Application.Security.Hashing;
using MediatR;

namespace IdentityService.Application.Features.Users.Queries.UserLoginQuery
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQueryRequest, UserLoginQueryResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITokenHelper _tokenHelper;

        public UserLoginQueryHandler(IUserReadRepository userReadRepository, ITokenHelper tokenHelper)
        {
            _userReadRepository = userReadRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<UserLoginQueryResponse> Handle(UserLoginQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetByEmail(request.Email);
            HashingHelper.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash);
            var accessToken = _tokenHelper.CreateToken(user, await _userReadRepository.GetRoleClaims(user.Id));
            return new UserLoginQueryResponse { Token = accessToken.Token };
        }
    }
}
