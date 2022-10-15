using IdentityService.Application.Abstraction.Persistence.RoleClaimRepository;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using IdentityService.Application.Utilities.ResponseModel;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.AddUserRoleCommand
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommandRequest, IResponseModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleClaimRepository _roleClaimReadRepository;

        public AddUserRoleCommandHandler(IUserRepository userRepository, IRoleClaimRepository roleClaimReadRepository)
        {
            _userRepository = userRepository;
            _roleClaimReadRepository = roleClaimReadRepository;
        }

        public async Task<IResponseModel> Handle(AddUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleClaimReadRepository.GetById(request.RoleClaimId);
            var user = await _userRepository.GetById(request.UserId);
            user.RoleClaims.Add(role);
            await _userRepository.Update(user);

            return new SuccessResponseModel()
            {
                Message = ""
            };
        }
    }
}
