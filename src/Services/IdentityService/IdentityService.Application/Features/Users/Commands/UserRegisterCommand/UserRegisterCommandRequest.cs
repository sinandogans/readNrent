using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UserRegisterCommand
{
    public class UserRegisterCommandRequest : IRequest<UserRegisterCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
