using IdentityService.Application.Utilities.ResponseModel;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.AddUserRoleCommand
{
    public class AddUserRoleCommandRequest : IRequest<IResponseModel>
    {
        public Guid RoleClaimId { get; set; }
        public Guid UserId { get; set; }
    }
}
