using IdentityService.Application.Abstraction.Persistence.RoleClaimRepository;
using IdentityService.Application.Abstraction.Persistence.UserRepository;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.AddUserRoleCommand
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommandRequest, AddUserRoleCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IRoleClaimReadRepository _roleClaimReadRepository;

        public AddUserRoleCommandHandler(IUserWriteRepository userWriteRepository, IRoleClaimReadRepository roleClaimReadRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _roleClaimReadRepository = roleClaimReadRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<AddUserRoleCommandResponse> Handle(AddUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var role = await _roleClaimReadRepository.GetById(request.RoleClaimId);
            var user = await _userReadRepository.GetById(request.UserId);
            user.RoleClaims.Add(role);
            await _userWriteRepository.Update(user);
            return new AddUserRoleCommandResponse();
        }
    }
}
