using IdentityService.Domain.Abstraction;

namespace IdentityService.Domain.Entities
{
    public class RoleClaim : IEntity
    {
        public RoleClaim()
        {
            Users = new HashSet<User>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
