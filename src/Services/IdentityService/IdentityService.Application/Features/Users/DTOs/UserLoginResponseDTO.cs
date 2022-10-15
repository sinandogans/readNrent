namespace IdentityService.Application.Features.Users.DTOs
{
    public class UserLoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
