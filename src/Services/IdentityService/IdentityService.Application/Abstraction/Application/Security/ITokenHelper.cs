using IdentityService.Application.Security.JWT;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Abstraction.Application.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<RoleClaim> roleClaims);
    }
}
