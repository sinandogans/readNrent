using IdentityService.Application.Utilities.ResponseModel;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UserRegisterCommand
{
    public class UserRegisterCommandRequest : IRequest<IResponseModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
