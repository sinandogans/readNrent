using IdentityService.Application.Features.Users.DTOs;
using IdentityService.Application.Utilities.ResponseModel;
using MediatR;

namespace IdentityService.Application.Features.Users.Commands.UserLoginCommand
{
    public class UserLoginCommandRequest : IRequest<IDataResponseModel<UserLoginResponseDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
