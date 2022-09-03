using MediatR;

namespace IdentityService.Application.Features.Users.Queries.UserLoginQuery
{
    public class UserLoginQueryRequest : IRequest<UserLoginQueryResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
