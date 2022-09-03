using IdentityService.Domain.Abstraction;

namespace IdentityService.Domain.Entities
{
    public class User : IEntity
    {
        public User()
        {
            RoleClaims = new HashSet<RoleClaim>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
