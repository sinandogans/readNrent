using UserService.Domain.Abstraction;

namespace UserService.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public ICollection<UserBook> Books { get; set; }
    }
}
