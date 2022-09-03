using MediatR;

namespace IdentityService.Application.Features.Users.Commands.AddUserRoleCommand
{
    public class AddUserRoleCommandRequest : IRequest<AddUserRoleCommandResponse>
    {
        public Guid RoleClaimId { get; set; }
        public Guid UserId { get; set; }
    }
}
